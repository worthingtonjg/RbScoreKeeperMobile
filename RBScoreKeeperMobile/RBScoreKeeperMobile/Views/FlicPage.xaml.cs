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
    public partial class FlicPage : ContentPage
    {
        FlicsViewModel viewModel;

        public FlicPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new FlicsViewModel(this);
        }

        protected async override void OnAppearing()
        {
            await viewModel.LoadAsync();
            base.OnAppearing();
        }
    }
}