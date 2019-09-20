using RBScoreKeeperMobile.ViewModels;

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

            BindingContext = viewModel = new PlayersViewModel(this);
        }

        protected async override void OnAppearing()
        {
            await viewModel.LoadAsync();
            base.OnAppearing();
        }
    }
}