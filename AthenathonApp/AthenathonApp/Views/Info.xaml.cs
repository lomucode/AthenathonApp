using Xamarin.Forms;
using System;

namespace AthenathonApp.Views
{
    public partial class Info : ContentPage
    {


        public Info()
        {
            InitializeComponent();
        }

        void OnExpanderTapped(object sender, EventArgs e)
        {
            Console.WriteLine("Expander tapped.");
        }

    }
}



