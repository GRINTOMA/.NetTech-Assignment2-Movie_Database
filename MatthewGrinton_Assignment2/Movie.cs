using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewGrinton_Assignment2
{
    public class Movie
    {
        public Movie(string n, DateTime d, string l, string g, int r, int dur, decimal p)
        {
            this.name = n;
            this.date = d;
            this.location = l;
            this.genre = g;
            this.rating = r;
            this.duration = dur;
            this.price = p;
        }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string location { get; set; }
        public string genre { get; set; }
        public int rating { get; set; }
        public int duration { get; set; }
        public decimal price { get; set; }
    }
    
}
