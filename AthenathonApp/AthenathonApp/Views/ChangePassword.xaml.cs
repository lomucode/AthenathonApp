using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AthenathonApp.Views
{
    public partial class ChangePassword : ContentPage
    {

        public ChangePassword()
        {
            InitializeComponent();
        }

        //push back to the navigation page
        public async void BackButton(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Framework(""));
        }

        //using save areas for iOS
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var safeInsets = On<iOS>().SafeAreaInsets();
            safeInsets.Left = 0;
            Padding = safeInsets;
        }
    }
}
