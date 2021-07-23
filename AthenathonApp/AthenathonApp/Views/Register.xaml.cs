using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AthenathonApp.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Register : ContentPage
    {
        PostUser u = new PostUser();

        public Register()
        {
            InitializeComponent();

            var theUser = new PostUser();
            u = theUser;
            BindingContext = theUser;

        }

        //reference to the login page
        public async void ButtonLogin(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Login());
            NavigationPage.SetHasBackButton(this, false);
        }

        //signing up
        public async void PushHome(object sender, System.EventArgs e)
        {
            string id = await RegisterUser();
            if (id != "")
            {
                await Navigation.PushModalAsync(new Framework(id));
            }
        }

        //signing up
        public async Task<string> RegisterUser()
        {
            PostUser user = new PostUser
            {
                Email = u.Email,
                PasswordHash = u.PasswordHash,
                PasswordHashTest = u.PasswordHashTest,
            };
            //checking for errors in the frontend
            if (user.PasswordHash != user.PasswordHashTest) {
                await DisplayAlert("Passwörter stimmen nicht überein", "Passwörter überprüfen", "OK");
                return "";
            }
            else if (!u.Email.Contains("student")) {
                await DisplayAlert("Falsche Email", "Bitte studentische E-Mail nutzen.", "OK");
                return "";
            }
            else if (user.Email != null && user.PasswordHash != null)
            {
                //if no errors detected in the frontend, send a api request
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("http://192.168.178.27:5000/api/Register", content);
                string result = await response.Content.ReadAsStringAsync();

                if (result != "\"user is already taken\"")
                {
                    //signing up successful
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<User>(jsonString);
                    string id = res.Id;
                    App.globalToken.Token = id;
                    App.globalToken.Email = u.Email;
                    return id;
                }
                else
                {
                    await DisplayAlert("Registrierung fehlgeschlagen", "E-Mail wird bereits genutzt", "OK");
                    return "";
                }
            }
            else
            {
                await DisplayAlert("Keine Daten eingegeben", "Bitte Daten eingeben", "OK");
                return "";
            }
        }

    }
}
