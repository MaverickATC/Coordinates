using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coordinates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        bool pointExists;
        Coords point;
        public AddPage()
        {
            InitializeComponent();

            pointExists = false;
        }

        public AddPage(Coords pointToAdd)
        {
            InitializeComponent();

            pointExists = true;
            point = pointToAdd;
            Coordinates.Text = point.ToString();
            Coordinates.IsEnabled = false;
        }

        private void PointName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Coordinates_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            if (!pointExists)
            {
                if (String.IsNullOrEmpty(PointName.Text))
                {
                    DisplayAlert("Warning", "Enter point name", "OK");
                }
                else if (String.IsNullOrEmpty(Coordinates.Text))
                {
                    DisplayAlert("Warning", "Enter coordinates", "OK");
                }

                if (!String.IsNullOrEmpty(PointName.Text) && (!String.IsNullOrEmpty(Coordinates.Text)))
                {
                    var p = new Coords(Coordinates.Text);
                    p.Name = PointName.Text;
                    App.Database.SaveItem(p);
                    this.Navigation.PopToRootAsync();
                }
            }
            if(pointExists)
            {
                if (!String.IsNullOrEmpty(PointName.Text))
                {
                    point.Name = PointName.Text;
                    App.Database.SaveItem(point);
                    this.Navigation.PopToRootAsync(); 
                }
                else
                {
                    DisplayAlert("Warning", "Enter point name", "OK");
                }

                
            }
        }

        private void CnlBtn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}