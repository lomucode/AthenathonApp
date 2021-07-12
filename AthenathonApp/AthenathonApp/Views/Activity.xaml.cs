using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AthenathonApp.Services;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Activity : ContentPage
    {
      

        public Activity()
        {

            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {



            ((Button)sender).IsVisible = false;


            label.IsVisible = true;
           

            // Simulates running process!


            label.IsVisible = false;
            Button2.IsVisible = true;
            label1.IsVisible = true;
            label2.IsVisible = true;
            label3.IsVisible = true;
            label4.IsVisible = true;
            label5.IsVisible = false;
            label6.IsVisible = false;
            label7.IsVisible = false;
            label8.IsVisible = false;


        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            DisplayAlert("Super", "Erfolgreich getrackt!", "OK");
            ((Button)sender).IsVisible = false;


            label.IsVisible = true;
            label1.IsVisible = false;
            label2.IsVisible = false;
            label3.IsVisible = false;
            label4.IsVisible = false;
            label5.IsVisible = true;
            label6.IsVisible = true;
            label7.IsVisible = true;
            label8.IsVisible = true;

            // Simulates running process!



            label.IsVisible = false;
            button1.IsVisible = true;

        }
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            DisplayAlert("Super", "Deine Daten wurden erfolgreich übermittelt :)", "OK");

        }
    }
}