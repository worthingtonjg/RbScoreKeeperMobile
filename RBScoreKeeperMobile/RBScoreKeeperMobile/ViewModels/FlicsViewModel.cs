using RBScoreKeeperMobile.Models;
using RBScoreKeeperMobile.Services;
using RBScoreKeeperMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RBScoreKeeperMobile.ViewModels
{
    public class FlicsViewModel : BaseViewModel
    {
        public List<Flic> Flics { get; set; }

        public Command ShowAddFlicModalCommand { get; set; }
        public Command DeleteFlicCommand { get; set; }

        public FlicsViewModel(INavigation navigation)
        {
            Navigation = navigation;

            ShowAddFlicModalCommand = new Command(async () => await ShowAddFlicModal());
            DeleteFlicCommand = new Command(async (o) => await DoDeleteFlicCommand(o));

            MessagingCenter.Subscribe<AddModalViewModel, string>(this, "DoSaveFlic", async (s, a) => await DoSavePlayer(s, a));
            MessagingCenter.Subscribe<AddModalViewModel>(this, "CancelSaveFlic", async (s) => await CancelSavePlayer(s));
        }

        public async Task LoadAsync()
        {
            var flics = await HttpHelper.Instance.GetListAsync<Flic>("flics");
            SetValue(() => Flics, flics);
        }

        private async Task DoDeleteFlicCommand(object o)
        {
            Flic f = o as Flic;
            await HttpHelper.Instance.DeleteAsync($"flics/{f.FlicId}");
            await LoadAsync();
        }

        private async Task ShowAddFlicModal()
        {
            await Navigation.PushAsync(new AddModal("Flic"));
        }

        private async Task DoSavePlayer(AddModalViewModel sender, string newFlicName)
        {
            await HttpHelper.Instance.PostAsync($"flics?name={newFlicName}", "");
            await Navigation.PopAsync();
        }

        private async Task CancelSavePlayer(AddModalViewModel sender)
        {
            await Navigation.PopAsync();
        }
    }
}
