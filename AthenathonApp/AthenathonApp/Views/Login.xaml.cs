using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        public async void ButtonRegister(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

    }
}
