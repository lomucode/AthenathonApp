using System;
using AthenathonApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AthenathonApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartingPage());
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
