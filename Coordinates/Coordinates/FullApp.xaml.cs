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
    public partial class FullApp : ContentPage
    {
        public FullApp()
        {
            InitializeComponent();
        }

        string tempCoords;
        double tempBearing, tempDist;
        int tempGateMile, tempNumPoints;

        List<Coords> final = new List<Coords>();
        List<Coords> miles = new List<Coords>();
        List<Coords> marks = new List<Coords>();
        List<Coords> gate = new List<Coords>();
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
        private void NumPoints_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NumPoints.Text != "")
            {
                int.TryParse(NumPoints.Text, out tempNumPoints);
            }
        }

        private void GateMile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (GateMile.Text != "")
            {
                int.TryParse(NumPoints.Text, out tempGateMile);
            }
        }
        private async void Calc_Clicked(object sender, EventArgs e)
        {
            final.Clear();
            miles.Clear();
            marks.Clear();
            gate.Clear();

            var startP = new Coords(tempCoords);

            final.Add(startP);
            Calculator.FindPointsLine(startP, tempBearing, tempDist, Calculator.Measures.NM, tempNumPoints, ref miles);
            final.Add(miles.Last());
            Calculator.FindFinalMarks(miles, tempBearing, ref marks);
            Calculator.FindGate(miles, tempGateMile, tempBearing, ref gate);

            await Navigation.PushAsync(new FullAppResult(final, marks, gate));

        }
    }
}