using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AthenathonApp.API;
using AthenathonApp.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Login : ContentPage
    {
        PostUser u = new PostUser();

        public Login()
        {
            InitializeComponent();

            var theUser = new PostUser();
            u = theUser;
            BindingContext = theUser;      

        }

        //go to login page
        public async void ButtonRegister(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
            NavigationPage.SetHasBackButton(this, false);
        }

        //signing in and go to the homescreen  
        public async void PushHome(object sender, System.EventArgs e)
        {
            string id = await LoginUser();
            if (id != "")
            {
                await Navigation.PushModalAsync(new Framework(id));
            }
        }

        public async Task<string> LoginUser()
        {
            PostUser user = new PostUser
            {
                Email = u.Email,
                PasswordHash = u.PasswordHash,
            };
            //frontend error check
            if (user.Email != null && user.PasswordHash != null) {
                //request the rest-api
                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("http://192.168.178.27:5000/api/Login", content);
                string result = await response.Content.ReadAsStringAsync();
                //check for errors
                    if (result != "\"Falsche Zugangsdaten\"" || result == "\"User not Existing in Database\"")
                    {
                        try
                        {
                        //if no errors included, logging in and safe the user data in a global reference
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<User>(jsonString);
                        string id = res.Id;
                            if(id == "")
                            {
                                await DisplayAlert("Noch nicht registriert", "Unter den angegebenen Daten ist kein Nutzer registriert", "OK");
                            }
                            App.globalToken.Token = id;
                            App.globalToken.Email = u.Email;
                            return id;
                        }
                        catch
                        {
                            return "";
                        }
                }
                else
                {
                    await DisplayAlert("Anmeldung fehlgeschlagen", "Falsche Zugangsdaten", "OK");
                    return "";
                }
            } else
            {
                await DisplayAlert("Keine Daten eingegeben", "Bitte Daten eingeben", "OK");
                return "";
            }
        }

        
    }
}
