using System;
using AthenathonApp.Services;
using AthenathonApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AthenathonApp
{
    public partial class App : Application
    {
        public static UserToken globalToken = new UserToken();

        public App()
        {
            UserToken token = new UserToken();
            token.Token = "cute";
            globalToken = token;
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
