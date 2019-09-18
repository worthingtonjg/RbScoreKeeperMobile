using Newtonsoft.Json;
using RBScoreKeeperMobile.Models;
using RBScoreKeeperMobile.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RBScoreKeeperMobile.ViewModels
{
    public class PlayersViewModel : BaseViewModel
    {
        public List<Player> Players { get; set; }
        public bool AddingPlayer { get; set; }
        public string NewPlayerName { get; set; }
        public Command AddPlayerCommand { get; set; }
        public Command DeletePlayerCommand { get; set; }
        public Command CancelAddPlayerCommand { get; set; }
        public Command SavePlayerCommand { get; set; }

        public PlayersViewModel()
        {
            AddPlayerCommand = new Command(() => {
                SetValue(() => NewPlayerName, string.Empty);
                SetValue(() => AddingPlayer, true);
            });


            CancelAddPlayerCommand = new Command(() =>
            {
                SetValue(() => AddingPlayer, false);
            });

            SavePlayerCommand = new Command(async () => await DoSavePlayerCommand());
            DeletePlayerCommand = new Command(async (o) => await DoDeletePlayerCommand(o));
        }

        private async Task DoDeletePlayerCommand(object o)
        {
            Player p = o as Player;
            await HttpHelper.Instance.DeleteAsync($"players/{p.PlayerId}");
            SetValue(() => AddingPlayer, false);
            await LoadAsync();
        }

        private async Task DoSavePlayerCommand()
        {
            await HttpHelper.Instance.PostAsync($"players?name={NewPlayerName}", "");
            SetValue(() => AddingPlayer, false);
            await LoadAsync();
        }

        internal async Task LoadAsync()
        {
            var players = await HttpHelper.Instance.GetListAsync<Player>("players");
            SetValue(() => Players, players);
        }
    }
}
