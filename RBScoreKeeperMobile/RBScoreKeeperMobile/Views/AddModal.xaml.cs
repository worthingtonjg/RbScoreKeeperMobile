using RBScoreKeeperMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RBScoreKeeperMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddModal : ContentPage
    {
        AddModalViewModel viewModel;

        public AddModal(string type)
        {
            InitializeComponent();

            BindingContext = viewModel = new AddModalViewModel(type);
        }
    }
}