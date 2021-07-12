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

        private void addData()
        {
            profile.Add(new Profile
            {
                Name = "John",
                University = "Universität Siegen",
                Role = "Student"
            });

        }

        
       



    }
}
