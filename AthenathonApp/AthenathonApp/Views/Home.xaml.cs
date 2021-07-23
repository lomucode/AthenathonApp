using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using AthenathonApp.Services;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Home : ContentPage
    {
        //GET FUNCTION DATA NEWS
        private readonly string newsUrl = "http://192.168.2.167:5000/api/News";
        private readonly HttpClient httpClientNews = new HttpClient();
        public ObservableCollection<News> TheNews { get; set; } = new ObservableCollection<News>();

        //GET FUNCTION DISTANZDATEN TRACKING
        private readonly string distanceUrl = "http://192.168.2.167:5000/api/DistanDatens";
        private readonly HttpClient httpClientDistanceData = new HttpClient();
        public ObservableCollection<DistanceEntry> DistanceEntries { get; set; } = new ObservableCollection<DistanceEntry>();

        List<string[]> act = new List<string[]>();
        List<string[]> activitiesToday = new List<string[]>();
        

        public Home()
        {
            InitializeComponent();
            NewsCarouselView.ItemsSource = TheNews;
            BindingContext = this;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Setup News
            var newsObj = await httpClientNews.GetStringAsync(newsUrl);
            var newsResult = JsonConvert.DeserializeObject<News[]>(newsObj);

            TheNews.Clear();

            foreach (var n in newsResult)
            {
                TheNews.Add(n);
            }

            //Setup Distance Data
            var distanceObj = await httpClientDistanceData.GetStringAsync(distanceUrl);
            var distanceResult = JsonConvert.DeserializeObject<DistanceEntry[]>(distanceObj);
            DateTime thisDay = DateTime.Today;
            string[] sportArts = { "Laufen", "Spazieren", "Schwimmen", "Fahrrad fahren", "Hiking", "Indoor-Biking", "Sonstiges" };


            //Activities
            var ent = new List<ChartEntry>();
            var entTotalActivity = new List<ChartEntry>();
            var entById = new List<ChartEntry>();
            var myActivities = new List<string[]>();
            var myActivitiesToday = new List<string[]>();
            double[] lastSevenDays = { 0, 0, 0, 0, 0, 0, 0 };
            double[] lastSevenDaysById = { 0, 0, 0, 0, 0, 0, 0 };
            double[] entireActivities = { 0, 0, 0, 0, 0, 0};

            DistanceEntries.Clear();

            foreach (var d in distanceResult)
            {
                DistanceEntries.Add(d);

                //last seven days activity in km 
                int dif = 6 - (DateTime.Today - d.DistanDatenDatum).Days;
                if (dif >= 0)
                {
                    lastSevenDays[dif] += d.Distanz; 
                }
                //last seven days activity in km by userId
                if(dif >= 0 && App.globalToken.Token == d.UserId)
                {
                    lastSevenDaysById[dif] += d.Distanz;

                    //last single activites
                    string[] temp = new string[] { d.DistanzArt, d.Distanz.ToString("0.00") };
                    myActivities.Add(temp);

                    //las single activites today
                    if(DateTime.Today == d.DistanDatenDatum)
                    {
                        myActivitiesToday.Add(temp);
                    }
                }

                //Sports distribution
                int index = Array.IndexOf(sportArts, d.DistanzArt);
                entireActivities[index] += d.Distanz;
            }
            //if no data available
            if (myActivities.Count == 0)
            {
                string[] temp = new string[] { "Noch nichts beigetragen :(", "0" };
                myActivities.Add(temp);
            }
            if (myActivitiesToday.Count == 0)
            {
                string[] temp = new string[] { "Heute nichts!:(", "0" };
                myActivitiesToday.Add(temp);
            }

            act = myActivities;
            activitiesToday = myActivitiesToday;

            MainCarouselView.ItemsSource = act;
            LastActivityView.ItemsSource = activitiesToday;

            //FOR LAST SEVEN DAYS BY USER-ID
            for (var j = 0; j < lastSevenDaysById.Length; j++)
            {

                var entryActivityTotal = new ChartEntry((float)lastSevenDaysById[j])
                {
                    Label = DateTime.Today.AddDays(j - 6).ToString("ddd"),
                    ValueLabel = lastSevenDaysById[j].ToString("0.00"),
                    Color = SKColor.Parse("#3262a8"),
                    ValueLabelColor = SKColor.Parse("#3262a8"),
                };
                entById.Add(entryActivityTotal);
            }
            var chartById = new LineChart() { Entries = entById, LabelTextSize = 30, };
            this.LastDaysById.Chart = chartById;


            //FOR LAST SEVEN DAYS GRAFIC
            for (var j = 0; j < lastSevenDays.Length; j++)
            {

                var entryActivityTotal = new ChartEntry((float)lastSevenDays[j])
                {
                    Label = DateTime.Today.AddDays(j - 6).ToString("ddd"),
                    ValueLabel = lastSevenDays[j].ToString("0.00"),
                    Color = SKColor.Parse("#3262a8"),
                    ValueLabelColor = SKColor.Parse("#3262a8"),
                };
                entTotalActivity.Add(entryActivityTotal);
            }
            var chartTotal = new LineChart() { Entries = entTotalActivity, LabelTextSize = 30, };
            this.TotalLastDays.Chart = chartTotal;


            //FOR SPORTS DISTRIBUTION GRAFIC
            for (var i=0; i < entireActivities.Length; i++)
            {
                Random ran = new Random();
                SKColor randomColor = SKColor.FromHsv(ran.Next(256), ran.Next(256), ran.Next(256));

                if (entireActivities[i] > 0)
                {

                var entry = new ChartEntry((float)entireActivities[i])
                {
                    Label = sportArts[i],
                    ValueLabel = entireActivities[i].ToString("0.00"),
                    Color = randomColor,
                    ValueLabelColor = randomColor
                };

                ent.Add(entry);
                }
            }

            var chart = new DonutChart() { Entries = ent, LabelTextSize = 30, };
            this.AllActivities.Chart = chart;



        }
    }
}
