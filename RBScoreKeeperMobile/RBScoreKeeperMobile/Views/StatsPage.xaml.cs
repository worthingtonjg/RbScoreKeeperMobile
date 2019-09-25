using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RBScoreKeeperMobile.Views
{
    public partial class StatsPage : ContentPage
    {
        public StatsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            WebView1.Reload();
        }
    }
}
