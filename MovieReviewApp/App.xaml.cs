using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieReviewApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignIn());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SignIn());
            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
