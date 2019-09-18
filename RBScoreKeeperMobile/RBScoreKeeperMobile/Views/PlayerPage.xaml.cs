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
    public partial class PlayerPage : ContentPage
    {
        PlayersViewModel viewModel;

        public PlayerPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PlayersViewModel();
        }

        protected async override void OnAppearing()
        {
            await viewModel.LoadAsync();
            base.OnAppearing();
        }
    }
}