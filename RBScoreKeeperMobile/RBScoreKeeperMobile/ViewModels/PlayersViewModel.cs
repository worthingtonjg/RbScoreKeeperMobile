using RBScoreKeeperMobile.Models;
using RBScoreKeeperMobile.Services;
using RBScoreKeeperMobile.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RBScoreKeeperMobile.ViewModels
{
    public class PlayersViewModel : BaseViewModel
    {
        public List<Player> Players { get; set; }
        public Command ShowAddPlayerModalCommand { get; set; }
        public Command DeletePlayerCommand { get; set; }

        public PlayersViewModel(INavigation navigation)
        {
            Navigation = navigation;

            ShowAddPlayerModalCommand = new Command(async () => await ShowAddPlayerModal());

            DeletePlayerCommand = new Command(async (o) => await DoDeletePlayerCommand(o));

            MessagingCenter.Subscribe<AddModalViewModel, string>(this, "DoSavePlayer", async(s, a) => await DoSavePlayer(s, a));
        }

        public async Task LoadAsync()
        {
            var players = await HttpHelper.Instance.GetListAsync<Player>("players");
            SetValue(() => Players, players);
        }

        private async Task ShowAddPlayerModal()
        {
            await Navigation.PushAsync(new AddModal("Player"));
        }

        private async Task DoSavePlayer(AddModalViewModel sender, string newPlayerName)
        {
            await HttpHelper.Instance.PostAsync($"players?name={newPlayerName}", "");
            await Navigation.PopAsync();
        }

        private async Task DoDeletePlayerCommand(object o)
        {
            Player p = o as Player;
            await HttpHelper.Instance.DeleteAsync($"players/{p.PlayerId}");
            await LoadAsync();
        }
    }
}
