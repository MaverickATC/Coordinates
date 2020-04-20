using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coordinates
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Coordsinates.db";
        public static CoordsRepository database;
        public static CoordsRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new CoordsRepository(DATABASE_NAME);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
