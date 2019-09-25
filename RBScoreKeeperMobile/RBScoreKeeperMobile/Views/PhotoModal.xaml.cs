using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBScoreKeeperMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RBScoreKeeperMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoModal : ContentPage
    {
        private PhotoModalViewModel viewModel;
        public PhotoModal()
        {
            InitializeComponent();

            BindingContext = viewModel = new PhotoModalViewModel();
        }
    }
}