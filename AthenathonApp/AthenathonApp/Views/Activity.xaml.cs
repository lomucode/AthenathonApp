using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AthenathonApp.Services;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Activity : ContentPage
    {
        //GET FUNCTION DISTANZDATEN TRACKING
        private readonly string distanceUrl = "http://192.168.2.167:5000/api/DistanDatens";
        private readonly HttpClient httpClientDistanceData = new HttpClient();
        public ObservableCollection<DistanceEntry> DistanceEntries { get; set; } = new ObservableCollection<DistanceEntry>();

        PostDistanceEntry entryDistance = new PostDistanceEntry();

        bool isGettingLocation;
        double distance = 0;
       
        Location start;
        Stopwatch stopwatch;


            public Activity()
        {
            InitializeComponent();
            var data = new PostDistanceEntry();
            entryDistance = data;
            BindingContext = data;

            stopwatch = new Stopwatch();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var distanceObj = await httpClientDistanceData.GetStringAsync(distanceUrl);
            var distanceResult = JsonConvert.DeserializeObject<DistanceEntry[]>(distanceObj);
            double temp = 0;

            foreach (var d in distanceResult)
            {
                temp += d.Distanz;
            }
            entryDistance.TotalDistance = temp.ToString("0.00");
        }

        public async Task SubmitRunningData()
        {
            if(distance > 0)
            {
                entryDistance.Distanz = distance.ToString();
            }

            PostDistanceEntry e = new PostDistanceEntry
            {
                Distanz = entryDistance.Distanz,
                DistanzArt = entryDistance.DistanzArt,
                UserId = "1b993051-aaee-497a-aae4-693b85c37518",
                DistanDatenDatum = DateTime.Today,
            };
            if (e.Distanz != null && e.DistanzArt != null)
            {
                
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(e);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("http://192.168.2.167:5000/api/DistanDatens", content);
                if (response.IsSuccessStatusCode)
                {
                await DisplayAlert("Super", "Deine Daten wurden erfolgreich übermittelt :)", "OK");
                    entryDistance.TotalDistance = (Convert.ToDouble(entryDistance.TotalDistance) + Convert.ToDouble(entryDistance.Distanz)).ToString("0.00");
                    entryDistance.Distanz = "0";
                }
                else
                {
                    await DisplayAlert("So nicht!", "Bitte nur Zahlen eintragen", "OK");
                    entryDistance.Distanz = "0";
                }

            }
            else
            {
                await DisplayAlert("Mach Sport!", "Du bist ja noch gar nicht gelaufen.", "OK");

            }
        }




            private async void GPSTracking_Button(object sender, EventArgs e)
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

        private async void Send_Data_Tracking_Button(object sender, EventArgs e)
        {

            await SubmitRunningData();
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
        async private void Send_Data_Manual(object sender, EventArgs e)
        {
            if (entryDistance.DistanzArt == null)
            {
                await DisplayAlert("Fehler!", "Wähle ein Sportart aus", "OK");
            } else
            {
            await SubmitRunningData();
            
            }

        }
    }
}