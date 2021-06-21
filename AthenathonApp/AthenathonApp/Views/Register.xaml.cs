using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }
        public async void ButtonLogin(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Login());
            NavigationPage.SetHasBackButton(this, false);
        }
        public async void PushHome(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Framework());
            NavigationPage.SetHasBackButton(this, false);
        }

    }
}
