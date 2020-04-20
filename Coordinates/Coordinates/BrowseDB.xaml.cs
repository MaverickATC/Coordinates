using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;

namespace Coordinates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowseDB : ContentPage
    {
        private List<Coords> pointsInDB;
        private List<Coords> pointsToShow;
        private List<Coords> pointsShowed;
        public BrowseDB()
        {
            InitializeComponent();

            pointsInDB = App.Database.GetItems().ToList();

            pointsToShow = new List<Coords>();

        }
        public BrowseDB(ref List<Coords> pointsOnMap)
        {
            InitializeComponent();

            pointsInDB = App.Database.GetItems().ToList();

            pointsToShow = new List<Coords>();

            pointsShowed = pointsOnMap;
            foreach (var p in pointsShowed)
            {
                foreach (var p2 in pointsInDB)
                {
                    if(p.Id == p2.Id)
                    {
                        p2.Show = true;
                    }
                }
            }
        }
        protected override void OnAppearing()
        {
            points.ItemsSource = pointsInDB;
            base.OnAppearing();

        }
        private async void Points_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var point = e.Item as Coords;

            if (!showCoords.IsChecked)
            {
                bool result = await DisplayAlert("Confirm", "Delete from database", "YES", "NO");

                if (result)
                {
                    App.Database.DeleteItem(point.Id);
                    pointsInDB = App.Database.GetItems().ToList();
                    points.ItemsSource = null;
                    points.ItemsSource = pointsInDB;
                }
            }
            else
            {
                await DisplayAlert("Coordinates", $"{point.Name}\t{point.ToString()}", "OK");
            }
        }
        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        private async void Show_Clicked(object sender, EventArgs e)
        {
            pointsToShow.Clear();
            foreach (var p in pointsInDB)
            {
                if (p.Show)
                {
                    pointsToShow.Add(p);
                }

            }
            await Navigation.PushAsync(new CustomMapPage(pointsToShow));
        }

        private void save_Clicked(object sender, EventArgs e)
        {
            pointsToShow.Clear();
            foreach (var p in pointsInDB)
            {
                if (p.Show)
                {
                    pointsToShow.Add(p);
                }

            }

            if (pointsToShow.Count == 0)
            {
                DisplayAlert("Warning", "Nothing to save", "OK");
            }
            else
            {
                DateTime dt = DateTime.Now;
                string filename = dt.ToString().Replace(' ', '_');
                
                PdfDocument document = new PdfDocument();
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for the page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

                //Draw the text
                for (int i = 0; i < pointsToShow.Count; i++)
                {
                    graphics.DrawString($"{pointsToShow[i].Name}\t\t{pointsToShow[i].ToString()}", font, PdfBrushes.Black, new PointF(0, (20 * i)));
                }

                //Save the document to the stream
                MemoryStream stream = new MemoryStream();
                document.Save(stream);

                //Close the document
                document.Close(true);

                //Save the stream as a file in the device and invoke it for viewing
                Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView(filename, "application/pdf", stream);
            }
        }
    }
}