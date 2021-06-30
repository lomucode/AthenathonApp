using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AthenathonApp.Services;
using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Profil : ContentPage
    {
        public event PropertyChangingEventHandler PropertyChanged;
        private ObservableCollection<Profile> Profile;
        public ObservableCollection<Profile> profile {
            get { return Profile; }
            set { Profile = value;

                PropertyChanged?.Invoke(this, new PropertyChangingEventArgs("profile"));
            }
                }

        
        public Profil()
        {
            profile = new ObservableCollection<Profile>();
            InitializeComponent();
        }

        public async void ChangePassword(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ChangePassword());
        }




    }
}
