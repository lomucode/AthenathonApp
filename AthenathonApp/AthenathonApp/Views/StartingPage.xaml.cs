using System;
using System.Collections.Generic;
using System.Net.Http;
using AthenathonApp.Services;
using AthenathonApp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AthenathonApp
{
    public partial class StartingPage : ContentPage
    {
        public StartingPage()
        {
            InitializeComponent();
        }

        public async void ButtonLogin(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Login());
        }

        public async void ButtonRegister(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
        }
    }


}
