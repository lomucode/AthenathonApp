using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using AthenathonApp.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Home : ContentPage
    {

        private const string monkeyUrl = "https://montemagno.com/monkeys.json";
        private readonly HttpClient httpClient = new HttpClient();

        public ObservableCollection<Monkey> Monkeys { get; set; } = new ObservableCollection<Monkey>();

        public Home()
        {
            InitializeComponent();
            BindingContext = this;
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
