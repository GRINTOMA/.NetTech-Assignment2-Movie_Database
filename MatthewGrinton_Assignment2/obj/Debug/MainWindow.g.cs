#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7DAD9BA917970694F2F087C668AC7FD0B70A60770F38B7A70B8E514779FEC144"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MatthewGrinton_Assignment2;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MatthewGrinton_Assignment2 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Movie_List;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Movie_Name;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Movie_Price;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Movie_Genre;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Movie_Date;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Movie_Rating;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Movie_Location;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Movie_Duration;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Movie_Duration_Text;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MatthewGrinton_Assignment2;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.Movie_Name_Focus_Changed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Movie_List = ((System.Windows.Controls.ListView)(target));
            
            #line 29 "..\..\MainWindow.xaml"
            this.Movie_List.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Movie_List_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 38 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.Movie_List_ColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 44 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.Movie_List_ColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 50 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.Movie_List_ColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 56 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.Movie_List_ColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Movie_Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 79 "..\..\MainWindow.xaml"
            this.Movie_Name.LostFocus += new System.Windows.RoutedEventHandler(this.Movie_Name_Focus_Changed);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Movie_Price = ((System.Windows.Controls.TextBox)(target));
            
            #line 132 "..\..\MainWindow.xaml"
            this.Movie_Price.LostFocus += new System.Windows.RoutedEventHandler(this.Movie_Price_Focus_Changed);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\MainWindow.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Edit = ((System.Windows.Controls.Button)(target));
            
            #line 151 "..\..\MainWindow.xaml"
            this.Edit.Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Delete = ((System.Windows.Controls.Button)(target));
            
            #line 161 "..\..\MainWindow.xaml"
            this.Delete.Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 172 "..\..\MainWindow.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Movie_Genre = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 14:
            this.Movie_Date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 15:
            this.Movie_Rating = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 16:
            this.Movie_Location = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 17:
            this.Movie_Duration = ((System.Windows.Controls.Slider)(target));
            
            #line 216 "..\..\MainWindow.xaml"
            this.Movie_Duration.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Movie_Duration_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 18:
            this.Movie_Duration_Text = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

