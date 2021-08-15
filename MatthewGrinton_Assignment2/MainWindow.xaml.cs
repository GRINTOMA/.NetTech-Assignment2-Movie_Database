using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace MatthewGrinton_Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    //For this project I populated my database with IMDB's top 50 movies. Using an MDF file connected to 
    //the program to allow for an easier transfer when submitting the project.


    //I've created an Enum for all of the different genres used in the database.
    enum Genre
    {
        Action,
        Adventure, 
        Biography, 
        Comedy, 
        Crime, 
        Drama, 
        Educational, 
        Family, 
        Fantasy,
        History, 
        Horror, 
        Musical, 
        Mystery, 
        Romance, 
        SciFi, 
        Thriller, 
        Western
    }
    public partial class MainWindow : Window
    {
        //The first of the four lists holds each of the movies currently in the database for easy access
        //in the program.
        public static List<Movie> movies = new List<Movie>();
        //The second list holds the genres listed above in the Enum
        public static List<string> genres = new List<string>();
        //The third list holds the unicode strings for the different ratings so that it will appear as
        //stars rather than just a number value.
        public static List<string> ratings = new List<string>();
        //Finally this list holds the two location variants that were listed for the project (International and Canadian).
        public static List<string> locations = new List<string>();

        //These two global variables are used for sorting the ListView when the
        //column is clicked.
        private GridViewColumnHeader listViewSort = null;
        private SortAdorner listViewSortAdorner = null;
        public MainWindow()
        {
            InitializeComponent();
            //The load data function populates each of the above lists with their most current information.
            loadData();
            //These four statements then provide the WPF window with an actual source for their data to display.
            Movie_List.ItemsSource = movies;
            Movie_Genre.ItemsSource = genres;
            Movie_Rating.ItemsSource = ratings;
            Movie_Location.ItemsSource = locations;

        }
        private void Movie_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //When this method is run first the list itself will refresh to ensure that the most accurate data
            //is available
            Movie_List.Items.Refresh();

            //This Linq statement determines which movie in the List has been selected
            var list = from movie in movies
                       where movie == Movie_List.SelectedItem
                       select movie;
            //This foreach statement allocates each of the movie properties to their respective fields
            foreach(var item in list)
            {
                Movie_Name.Text = item.name;
                Movie_Date.SelectedDate = item.date;
                Movie_Location.SelectedItem = item.location;
                Movie_Genre.SelectedItem = item.genre;
                Movie_Duration.Value = item.duration;
                Movie_Duration_Text.Content = item.duration + " min";
                Movie_Price.Text = item.price.ToString();
                Movie_Rating.SelectedItem = ratings[item.rating - 1];
            }
            
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //When the add movie button is clicked first the program checks to see if the fields are empty
            if(Movie_Name.Text == "" || 
                Movie_Date.SelectedDate == null || 
                Movie_Location.Text == "" || 
                Movie_Genre.SelectedItem == null ||  
                Movie_Duration.Value == 0 || 
                Movie_Price.Text == "")
            {
                //If they are this message appears as a pop-up
                MessageBox.Show("Field left empty. Name, Date, Location, Genre, Duration, or Price must be filled in.");
            }
            else
            {
                //If each of the fields are populated correctly this sets each of the fields to a variable
                string name = Movie_Name.Text;
                DateTime date = Movie_Date.SelectedDate.Value;
                string location = Movie_Location.SelectedItem.ToString();
                string genre = Movie_Genre.Text;
                int duration = (int)Movie_Duration.Value;
                decimal price = decimal.Parse(Movie_Price.Text);
                int rating = Movie_Rating.SelectedIndex + 1;
                //First it adds it to the local list to be updated in the ListView
                movies.Add(new Movie(name, date, location, genre, rating, duration, price));
                //The ListView is then refreshed to visually reflect the change
                Movie_List.Items.Refresh();
                //Next the data is sent to the insertData() method which handles querying it to the database
                insertData(name, date, location, genre, rating, duration, price);
                //Finally all of the fields are cleared to allow the user to continue using the program
                clearFields();
            }

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            //The same as above when the edit movie button is clicked it first checks to make sure none of the fields are empty
            if (Movie_Name.Text == "" ||
                Movie_Date.SelectedDate == null ||
                Movie_Location.Text == "" ||
                Movie_Genre.SelectedItem == null ||
                Movie_Duration.Value == 0 ||
                Movie_Price.Text == "")
            {
                //Once again if any are this message appears in a pop-up
                MessageBox.Show("Field left empty. Name, Date, Location, Genre, Duration, or Price must be filled in.");
            }
            else
            {
                //Once the fields are filled out correctly a similar process happens to when a movie is added.
                //Each field is set to a local variable
                string name = Movie_Name.Text;
                DateTime date = Movie_Date.SelectedDate.Value;
                string location = Movie_Location.SelectedItem.ToString();
                string genre = Movie_Genre.Text;
                int duration = (int)Movie_Duration.Value;
                decimal price = decimal.Parse(Movie_Price.Text);
                int rating = Movie_Rating.SelectedIndex + 1;
                //Then a Linq statement is used to determine which movie in the List is being edited
                var update = from movie in movies
                             where movie.name == name
                             select movie;
                //Then this foreach statement updates the List to reflect the changes made to the movie
                foreach (var item in update)
                {
                    item.name = name;
                    item.date = date;
                    item.location = location;
                    item.genre = genre;
                    item.duration = duration;
                    item.price = price;
                    item.rating = rating;
                }
                //Then the updateData() method is run to query the database with the changes
                updateData(name, date, location, genre, rating, duration, price);
                //Finally the ListView is refreshed to reflect any of the changes made
                Movie_List.Items.Refresh();
                //And the fields are cleared 
                clearFields();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //For the delete it the movies name and date are run through a LinQ statement to determine which film is being deleted.
            //This is because while some movies may have similar names it is highly improbably that a movie with identical names is released
            //on the same day. This then provides the movie's ID.
            string name = Movie_Name.Text;
            DateTime date = Movie_Date.SelectedDate.Value;
            var delete = from movie in movies
                         where movie.name == name
                         select movie;
            int index = 0;
            //This sets an integer value to be used as the index.
            foreach(var item in delete)
            {
               index = movies.IndexOf(item);
            }
            //This will remove the specified movie from the list.
            movies.RemoveAt(index);
            //Name and date are then passed to the deleteDate() method to be used to query the database for the removal of said movie.
            deleteData(name, date);
            //The ListView is the refreshed.
            Movie_List.Items.Refresh();
            //And once again fields are cleared.
            clearFields();
        }
        //This method is used to close the program when the close button is clicked.
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        //The clearFields() method sets all fields to either a null value or an empty string depending on the 
        //datatype taken by the field.
        private void clearFields()
        {
            Movie_Name.Text = "";
            Movie_Date.SelectedDate = null;
            Movie_Location.SelectedItem = null;
            Movie_Genre.SelectedItem = null;
            Movie_Rating.SelectedItem = null;
            Movie_Duration.Value = 0;
            Movie_Price.Text = "";
        }
        //This establishes a connection string to be used when connecting to the databse.
        static string GetConnectionString(string connectionStringName)
        {
            ConfigurationBuilder configBuild = new ConfigurationBuilder();
            configBuild.SetBasePath(System.IO.Directory.GetCurrentDirectory());
            configBuild.AddJsonFile("config.json");
            IConfiguration config = configBuild.Build();

            return config["ConnectionStrings:" + connectionStringName];
        }
        //As mentioned above the loadData() method populates each of the lists and runs the initial query to the database to get
        //all current data.
        static void loadData()
        {
            genres.Add(Enum.GetName(typeof(Genre), Genre.Action));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Adventure));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Biography));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Comedy));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Crime));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Drama));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Educational));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Family));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Fantasy));
            genres.Add(Enum.GetName(typeof(Genre), Genre.History));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Horror));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Musical));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Mystery));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Romance));
            genres.Add(Enum.GetName(typeof(Genre), Genre.SciFi));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Thriller));
            genres.Add(Enum.GetName(typeof(Genre), Genre.Western));

            ratings.Add("\u2605\u2606\u2606\u2606\u2606");
            ratings.Add("\u2605\u2605\u2606\u2606\u2606");
            ratings.Add("\u2605\u2605\u2605\u2606\u2606");
            ratings.Add("\u2605\u2605\u2605\u2605\u2606");
            ratings.Add("\u2605\u2605\u2605\u2605\u2605");

            locations.Add("Canadian");
            locations.Add("International");

            string conn = GetConnectionString("MovieList");
            //This pulls all of the data from the database to be used to fill the lists.
            using (SqlConnection scon = new SqlConnection(conn))
            {
                SqlCommand cmd = scon.CreateCommand();
                cmd.CommandText = "SELECT * FROM Movie";
                Console.WriteLine(conn);
                scon.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int id = (int)read[0];
                    string name = read[1].ToString();
                    DateTime date = DateTime.Parse(read[2].ToString());
                    string location = read[3].ToString();
                    string genre = read[4].ToString();
                    int rating = int.Parse(read[5].ToString());
                    int duration = int.Parse(read[6].ToString());
                    decimal price = decimal.Parse(read[7].ToString());

                    movies.Add(new Movie(name, date, location, genre, rating, duration, price));
                }
            }
        }
        //The insertData() method takes the provided data and sends it to the database.
        static void insertData(string m_name, DateTime m_date, string m_location, string m_genre, int m_rating, int m_duration, decimal m_price)
        {
            string conn = GetConnectionString("MovieList");
            using (SqlConnection scon = new SqlConnection(conn))
            {
                SqlCommand cmd = scon.CreateCommand();
                cmd.CommandText = "insert into Movie (MovieName, ReleaseDate, Location, Genre, Rating, Duration, Price) " +
                    "values(@name, @date, @location, @genre, @rating, @duration, @price)";
                cmd.Parameters.AddWithValue("name", m_name);
                cmd.Parameters.AddWithValue("date", m_date);
                cmd.Parameters.AddWithValue("location", m_location);
                cmd.Parameters.AddWithValue("genre", m_genre);
                cmd.Parameters.AddWithValue("rating", m_rating);
                cmd.Parameters.AddWithValue("duration", m_duration);
                cmd.Parameters.AddWithValue("price", m_price);
                scon.Open();
                int rows_inserted = cmd.ExecuteNonQuery();
                //This displays once the database connection has been made successfully and the query has run.
                MessageBox.Show(m_name + " was added to the database.");

            }
        }
        //Similar to insertData() the updataData() method is provided each of the fields data and queryies the database.
        static void updateData(string m_name, DateTime m_date, string m_location, string m_genre, decimal m_rating, int m_duration, decimal m_price)
        {
            string conn = GetConnectionString("MovieList");
            using (SqlConnection scon = new SqlConnection(conn))
            {
                //This first query gets the MovieID based on the name and date (reason specified in Delete_Button_Click())
                SqlCommand getId = scon.CreateCommand();
                getId.CommandText = "SELECT MovieID FROM Movie WHERE MovieName = @name and ReleaseDate = @date";
                getId.Parameters.AddWithValue("name", m_name);
                getId.Parameters.AddWithValue("date", m_date);
                int m_id = 0;
                scon.Open();
                SqlDataReader read = getId.ExecuteReader();
                while (read.Read())
                {
                    m_id = (int)read[0];
                }
                scon.Close();
                //Once the MovieID is known the database then updates the movie the MovieID refers to.
                SqlCommand cmd = scon.CreateCommand();
                cmd.CommandText = "UPDATE movie " +
                    "SET ReleaseDate = @date, " +
                    "Location = @location, " +
                    "Genre = @genre, " +
                    "Rating = @rating, " +
                    "Duration = @duration, " +
                    "Price = @price " +
                    "WHERE MovieID = @id";
                cmd.Parameters.AddWithValue("id", m_id);
                cmd.Parameters.AddWithValue("date", m_date);
                cmd.Parameters.AddWithValue("location", m_location);
                cmd.Parameters.AddWithValue("genre", m_genre);
                cmd.Parameters.AddWithValue("rating", m_rating);
                cmd.Parameters.AddWithValue("duration", m_duration);
                cmd.Parameters.AddWithValue("price", m_price);
                scon.Open();
                int rows_updated = cmd.ExecuteNonQuery();
                //Once the update query is successfull this message displays as a pop-up.
                MessageBox.Show(m_name + " was updated in the database.");
            }
        }
        //Finally the deleteData() method only utilizes the name and date fields.
        static void deleteData(string m_name, DateTime m_date)
        {
            string conn = GetConnectionString("MovieList");
            using (SqlConnection scon = new SqlConnection(conn))
            {
                //Once again the first query is to determine the MovieID (reason specified in Delete_Button_Click()).
                SqlCommand getId = scon.CreateCommand();
                getId.CommandText = "SELECT MovieID FROM Movie WHERE MovieName = @name and ReleaseDate = @date";
                getId.Parameters.AddWithValue("name", m_name);
                getId.Parameters.AddWithValue("date", m_date);
                int m_id = 0;
                scon.Open();
                SqlDataReader read = getId.ExecuteReader();
                while (read.Read())
                {
                    m_id = (int)read[0];
                }
                scon.Close();
                //This next query deletes the movie the MovieID refers to in the database.
                SqlCommand cmd = scon.CreateCommand();
                cmd.CommandText = "DELETE FROM movie WHERE MovieID = @id";
                cmd.Parameters.AddWithValue("id", m_id);
                scon.Open();
                int rows_removed = cmd.ExecuteNonQuery();
                //Once the delete query is successfull this message displays as a pop-up.
                MessageBox.Show(m_name + " was removed from the database.");
            }
        }
        //When the slider used for the MovieDuration is changed this method runs. This method is used to change the label displaying
        //what the slider represents.
        private void Movie_Duration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            decimal time = (decimal)Movie_Duration.Value;
            Movie_Duration_Text.Content = time + " min";
        }
        //When the user finishes entering the movie name and selects another field or presses one of the buttons this method runs.
        //This method is used to check two things:
            //First this method validates the data in MovieName contains at least one letter.
            //Second it is used as a psudo-search function for the user.
                //What I mean by that is rather than forcing the user to press a search button
                //cloging up the window more. If the user fills in a MovieName that already exists
                //the program will auto select it for them and populate all of the fields accordingly.
        private void Movie_Name_Focus_Changed(object sender, RoutedEventArgs e)
        {
            //This is a regular expression used to check if the Movie_Name field contains any letters.
            int stringCheck = Regex.Matches(Movie_Name.Text, @"[a-zA-Z]").Count;
            //If the regular expression comes back as 0 that means that there is no lower case or capital letters in the
            //field. As well a check to see if anything is present in the field when the focus is changed is run as well
            //to make sure the error pop-up doesn't show up every time the user changes fields when it's empty.
            if (stringCheck == 0 && Movie_Name.Text != "")
            {
                //If the stringCheck variable is 0, and the Movie_Name field isn't empty this message displays as a pop-up.
                MessageBox.Show("Invalid movie name. Name requires at least one letter.");
                Movie_Name.Text = "";
            }
            //The second part of this function as explained above acts as the search functionality for the program.
            //The method nameCheck() is run using the Movie_Name field data, and if it returns a bool value of true that
            //means that the movie in the Movie_Name field already exists in the database.
            if (nameCheck(Movie_Name.Text))
            {
                var search = from movie in movies
                             where movie.name == Movie_Name.Text
                             select movie;
                //This loop takes the information in the database already that matches the movie's name
                //then sets the ListView's selected item to that movie, as well as all of the fields
                //are filled with the movies data.
                foreach (var item in search)
                {
                    Movie_List.SelectedItem = item;
                    Movie_Name.Text = item.name;
                    Movie_Date.SelectedDate = item.date;
                    Movie_Location.SelectedItem = item.location;
                    Movie_Genre.SelectedItem = item.genre;
                    Movie_Duration.Value = item.duration;
                    Movie_Duration_Text.Content = item.duration + " min";
                    Movie_Price.Text = item.price.ToString();
                    Movie_Rating.SelectedItem = ratings[item.rating-1];
                }
            }
        }
        //This method checks to ensure the price input into the Movie_Price field only contains numbers.
        private void Movie_Price_Focus_Changed(object sender, RoutedEventArgs e)
        {
            //This regular expression is used to check the field for anything other than numbers.
            //It will return false if a character that isn't a number is entered.
            //An error message is then displayed as a pop-up
            Regex r = new Regex(@"^[0-9]");
            if(r.IsMatch(Movie_Price.Text) == false && Movie_Price.Text != "")
            {
                MessageBox.Show("Invalid movie price. Price must be a number with two decimal places.");
                Movie_Price.Text = "";
            }
        }
        //This is the above mentioned nameCheck() method which takes in a string name and checks it against the 
        //List of movies. If count doesn't equal 0 then it has found a movie that exists in the database with that name already.
        static bool nameCheck(string name)
        {
            int count = 0;
            var check = from movie in movies
                        where movie.name == name
                        select movie;
            foreach(var item in check)
            {
                count++;
            }
            return count > 0;
        }
        
        //The rest of the program is dedicated to sorting the ListView columns

        //First a method for when a column header is clicked. This method is referenced on each of the column headers.
        private void Movie_List_ColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //These variables determine which column header was clicked. As well as the column data
            //for example if the Name column was clicked the variable sort would be given the value
            //of "name".
            GridViewColumnHeader col = (sender as GridViewColumnHeader);
            string sort = col.Tag.ToString();
            if(listViewSort != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSort).Remove(listViewSortAdorner);
                Movie_List.Items.SortDescriptions.Clear();
            }

            ListSortDirection dir = ListSortDirection.Ascending;
            if(listViewSort == col && listViewSortAdorner.Direction == dir)
            {
                dir = ListSortDirection.Descending;
            }
            listViewSort = col;
            listViewSortAdorner = new SortAdorner(listViewSort, dir);
            AdornerLayer.GetAdornerLayer(listViewSort).Add(listViewSortAdorner);
            Movie_List.Items.SortDescriptions.Add(new SortDescription(sort, dir));
        }
    }
    //This creates the SortAdorner class, this class is used to sort the column headers in ascending and descending order.
    public class SortAdorner : Adorner
    {
        //The variable aGeo refers to the ascending sort order.
        private static Geometry aGeo =
            Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");
        //The variable dGeo refers to the descending sort order.
        private static Geometry dGeo =
            Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

        //This method gets the direction for the SortAdorner to determine which way the columns need to be sorted.
        public ListSortDirection Direction { get; private set; }

        public SortAdorner(UIElement e, ListSortDirection dir)
            : base(e)
        {
            this.Direction = dir;
        }
        //The OnRender() method is being used for when a column is clicked, it will draw a small arrow next to the column.
        //This will be used to show the user which direction the column is being sorted.
        //Since the first thing that will always happen is ascending sort order the method goes off of the assumption
        //that it is ascending sort order.
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (AdornedElement.RenderSize.Width < 20)
                return;

            TranslateTransform transform = new TranslateTransform
                (
                    AdornedElement.RenderSize.Width - 15,
                    (AdornedElement.RenderSize.Height - 5) / 2
                );
            drawingContext.PushTransform(transform);

            Geometry geometry = aGeo;
            //This checks if the sort order is descending and will flip the arrow accordingly.
            if (this.Direction == ListSortDirection.Descending)
                geometry = dGeo;
            drawingContext.DrawGeometry(Brushes.Black, null, geometry);

            drawingContext.Pop();
        }
    }
}
