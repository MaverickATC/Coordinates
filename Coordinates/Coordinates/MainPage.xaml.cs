using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Coordinates
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void FPoint_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FindPoint());
        }

        private async void FMultPoints_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FindMultiPoints());
        }

        private async void FFullApp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FullApp());
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("ABOUT", "\t\tMade by Oleksii Nedilko\n\t\t2020", "OK");
        }

        private async void Cmap_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomMapPage());
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void Db_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrowseDB());
        }
    }
}
