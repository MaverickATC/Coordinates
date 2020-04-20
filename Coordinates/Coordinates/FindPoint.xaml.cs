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
    public partial class FindPoint : ContentPage
    {
        public FindPoint()
        {
            InitializeComponent();
        }


        string tempCoords;
        double tempBearing, tempDist;

        private void Dist_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Dist.Text != "")
            {
                tempDist = Convert.ToDouble(Dist.Text);
            }
        }

        private void Bearing_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Bearing.Text != "")
            {
                tempBearing = Extensions.ToRad(Convert.ToDouble(Bearing.Text));
            }
        }

        private void Coordinates_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (Coordinates.Text != "")
            {
                tempCoords = Coordinates.Text;
                if ((tempCoords[tempCoords.Length - 1] != 'e') || (tempCoords[tempCoords.Length - 1] != 'E'))
                {
                    Coordinates.BackgroundColor = Color.Red;
                    Calc.IsEnabled = false;
                }
                if ((tempCoords[tempCoords.Length - 1] == 'e') || (tempCoords[tempCoords.Length - 1] == 'E'))
                {
                    Coordinates.BackgroundColor = Color.White;
                    Calc.IsEnabled = true;
                }
            }
        }
        private async void Calc_Clicked(object sender, EventArgs e)
        {
            var startP = new Coords(tempCoords);
            var measure = Calculator.Measures.NM;
            if(km_check.IsChecked)
            {
                measure = Calculator.Measures.KM;
            }
            var newP = Calculator.FindPoint(startP, tempBearing, tempDist, measure);

            bool result = await DisplayAlert("Confirm", "Add to database", "YES", "NO");

            if (result)
            {
                await Navigation.PushAsync(new AddPage(newP));
            }
            else
            {
                await DisplayAlert("New point", newP.ToString(), "OK");
            }
        }
    }
}