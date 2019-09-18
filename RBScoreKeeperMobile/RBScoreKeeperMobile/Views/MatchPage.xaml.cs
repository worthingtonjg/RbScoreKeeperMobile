using RBScoreKeeperMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RBScoreKeeperMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        MatchViewModel viewModel;

        public MatchPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MatchViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadAsync();
        }
    }
}