
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AthenathonApp.Views
{
    public partial class Framework : TabbedPage
    {
        public string _id;

        public Framework(string id)
        {
            InitializeComponent();
            _id = id;
            BindingContext = _id;
        }
    }
}