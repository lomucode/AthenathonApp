using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AthenathonApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Activity : ContentPage
    {
        bool isGettingLocation;
        double distance = 0;
        Location start;
        Stopwatch stopwatch;


        public Activity()
        {

            InitializeComponent();
            stopwatch = new Stopwatch();

        }




        private async void Button_Clicked(object sender, EventArgs e)
        {
            ((Button)sender).IsVisible = false;
            label.IsVisible = true;
            Button2.IsVisible = true;
            label1.IsVisible = true;
            label2.IsVisible = true;
            label3.IsVisible = true;
            label4.IsVisible = true;
            label5.IsVisible = false;
            label6.IsVisible = false;
            label7.IsVisible = false;
            label8.IsVisible = false;

            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromSeconds(0.0015), () =>
            {
                label1.Text = stopwatch.Elapsed.ToString();

                return true;

            }

            );



            isGettingLocation = true;
             

            Location currentPosition;
            start = await Geolocation.GetLocationAsync(new
                      GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            double km;

            while (isGettingLocation)

            {
                currentPosition = await Geolocation.GetLocationAsync(new
                       GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));

                km = Location.CalculateDistance(start, currentPosition, DistanceUnits.Kilometers);

                distance += km;

                start = currentPosition;



                await Task.Delay(500);

                label3.Text = $"{Math.Round(distance, 2)}";


            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            await DisplayAlert("Aktivität getrackt!", "Deine Distanz wurde erfolgreich getrackt :)", "OK");
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

            isGettingLocation = false;
            distance = 0;

            stopwatch.Reset();


        }
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            DisplayAlert("Super", "Deine Daten wurden erfolgreich übermittelt :)", "OK");

        }
    }
}