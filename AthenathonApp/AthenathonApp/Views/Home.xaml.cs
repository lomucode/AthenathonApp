using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly ChartEntry[] entries = new[]
        {
            new ChartEntry(212)
            {
                Label="Montag",
                ValueLabel="112",
                Color = SKColor.Parse("2c3e50")
            },
            new ChartEntry(512)
            {
                Label="Dienstag",
                ValueLabel="648",
                Color = SKColor.Parse("#77d065")
            }
        };


        private const string monkeyUrl = "https://montemagno.com/monkeys.json";
        private readonly HttpClient httpClient = new HttpClient();

        public ObservableCollection<Monkey> Monkeys { get; set; } = new ObservableCollection<Monkey>();

        public Home()
        {
            InitializeComponent();
            chartViewLine.Chart = new LineChart { Entries = entries,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelTextSize = 30, LabelOrientation=Orientation.Horizontal };

            chartViewPie.Chart = new PieChart
            {
                Entries = entries,
                //ValueLabelOrientation = Orientation.Horizontal,
                LabelTextSize = 30,
                //LabelOrientation = Orientation.Horizontal
            };
            BindingContext = this;
            var names = new List<string[]>
            {
                new string[]{"Laufen", "30,4"},
                new string[]{"Skaten", "30,4"},
                new string[]{"Ski fahren", "30,4"},
                new string[]{"Schwimmen", "30,4"},
            };
            MainCarouselView.ItemsSource = names;
            LastActivityView.ItemsSource = names;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var monkeyJson = await httpClient.GetStringAsync(monkeyUrl);
            var monkeys = JsonConvert.DeserializeObject<Monkey[]>(monkeyJson);

            Monkeys.Clear();

            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }

    }
}
