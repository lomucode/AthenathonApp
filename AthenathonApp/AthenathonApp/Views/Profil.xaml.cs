using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AthenathonApp.Services;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Profil : ContentPage
    {
        Profile currentUser = new Profile();

        public Profil()
        {
            InitializeComponent();
            var cur = new Profile();
            cur.Name = App.globalToken.Email.Substring(0, App.globalToken.Email.IndexOf("."));
            cur.Role = "Student";
            cur.University = "Universität Siegen";
            currentUser = cur;
            BindingContext = cur;
        }

        public async void ChangePassword(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ChangePassword());
        }
        public async void LogOut(object sender, System.EventArgs e)
        {
            App.globalToken.Email = "";
            App.globalToken.Token = "";
            await Navigation.PushModalAsync(new StartingPage());
        }
}
}
