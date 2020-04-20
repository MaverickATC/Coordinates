using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Coordinates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomMapPage : ContentPage
    {
        List<Coords> pointsToShow;
        public CustomMapPage()
        {
            InitializeComponent();
            //var c = new Coords("49.8119444444N23.9513888889E");
            //c.Name = "test point";
            //var p = new CustomPin(c)
            //{
            //    //Position = new Position(49.8119444444, 23.9513888889),
            //    //Label = "ok"
            //};
            //map.CustomPins.Add(p);

            pointsToShow = new List<Coords>();

            Polyline polyline = new Polyline
            {
                StrokeWidth = 8,
                StrokeColor = Color.FromHex("#1BA1E2"),
                //FillColor = Color.FromHex("#881BA1E2"),
                Geopath =
    {
        //new Position(47.6368678, -122.137305),
        //new Position(47.6368894, -122.134655),
        new Position(47.6359424, -122.134655),
        new Position(47.6359496, -122.1325521),
        new Position(47.6424124, -122.1325199),
        new Position(47.642463,  -122.1338932),
        new Position(47.6406414, -122.1344833),
        new Position(47.6384943, -122.1361248),
        new Position(47.6372943, -122.1376912)
    }
            };

            // add the polygon to the map's MapElements collection
            map.MapElements.Add(polyline);
            List<Coords> l = new List<Coords>
                {
                    new Coords(Extensions.ToRad(47.6368678), Extensions.ToRad(-122.137305)),
                    new Coords(Extensions.ToRad(47.6368894), Extensions.ToRad(-122.134655))
                };
            var customPolyline = new Line(l);
            map.MapElements.Add(customPolyline);


            Polygon polygon = new Polygon
            {
                StrokeWidth = 8,
                StrokeColor = Color.FromHex("#1BA1E2"),
                FillColor = Color.FromHex("#881BA1E2"),
                Geopath =
    {
        new Position(47.6368678, -122.137305),
        new Position(47.6368894, -122.134655),
        new Position(47.6359424, -122.134655),
        new Position(47.6359496, -122.1325521),
        new Position(47.6424124, -122.1325199),
        new Position(47.642463,  -122.1338932),
        new Position(47.6406414, -122.1344833),
        new Position(47.6384943, -122.1361248),
        new Position(47.6372943, -122.1376912)
    }
            };
        }
        public CustomMapPage(List<Coords> list)
        {
            InitializeComponent();
            pointsToShow = list;
            foreach (var p in pointsToShow)
            {
                map.CustomPins.Add(new CustomPin(p));
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();


        }

        private async void AddBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrowseDB(ref pointsToShow));
        }
    }
}