using System;
using System.Collections.Generic;
using AthenathonApp.API;
using Refit;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Login : ContentPage
    {
        IMyAPI myAPI;

        myAPI = RestService.For<IMyAPI>("http://192.168.187.202:5000");

        

        public Login()
        {
            InitializeComponent();
        }
        public async void ButtonRegister(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
            NavigationPage.SetHasBackButton(this, false);
        }



        public async void PushHome(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Framework());
        }
    }
}
