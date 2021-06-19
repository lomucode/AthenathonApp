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
            await Navigation.PushAsync(new Login());
        }

    }
}
