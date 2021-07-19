using System;
using System.Collections.Generic;
using System.Net.Http;
using AthenathonApp.Services;
using AthenathonApp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AthenathonApp
{
    public partial class StartingPage : ContentPage
    {
        public StartingPage()
        {
            InitializeComponent();
        }

        public async void ButtonLogin(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Login());
        }

        public async void ButtonRegister(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
        }

        //    async void Button_Clicked(System.Object sender, System.EventArgs e)
        //    {
        //        var httpClient = new HttpClient();
        //        var resultJson = await httpClient.GetStringAsync("http://192.168.178.27:5000/api/AspNetUsers");

        //        var resultUsers = JsonConvert.DeserializeObject<User[]>(resultJson);
        //        users.ItemsSource = resultUsers;
        //    }
    }


}
