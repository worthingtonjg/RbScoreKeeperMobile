using RBScoreKeeperMobile.Models;
using RBScoreKeeperMobile.Services;
using RBScoreKeeperMobile.ViewModels.ChildViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace RBScoreKeeperMobile.ViewModels
{
    public class MatchViewModel : BaseViewModel
    {
        public bool MatchIsActive { get; set; }
        public Match Match { get; set; }
        public List<MatchPlayersViewModel> Players { get; set; }
        public int FlicCount { get; set; }

        public Command StartMatchCommand { get; set; }
        public Command EndMatchCommand { get; set; }
        public Command CancelMatchCommand { get; set; }
        public Command NextGameCommand { get; set; }
        public Command ResetGameCommand { get; set; }

        public MatchViewModel()
        {
            StartMatchCommand = new Command(async () => await DoStartMatchCommand());
            EndMatchCommand = new Command(async () => await DoEndMatchCommand());
            CancelMatchCommand = new Command(async () => await DoCancelMatchCommand());
            NextGameCommand = new Command(async () => await DoNextGameCommand());
            ResetGameCommand = new Command(async () => await DoResetGameCommand());
        }

        private async Task DoStartMatchCommand()
        {
            var selected = Players.Where(p => p.Selected).ToList();

            if (selected.Count < 2 || selected.Count > FlicCount) return;

            var playerIds = selected.Select(s => s.Id).ToList();

            await HttpHelper.Instance.PostAsync("match/create", playerIds);
            await LoadAsync();
        }

        private async Task DoResetGameCommand()
        {
            await HttpHelper.Instance.PostAsync("match/game/reset", "");
        }

        private async Task DoNextGameCommand()
        {
            await HttpHelper.Instance.PostAsync("match/game/next", "");
        }

        private async Task DoCancelMatchCommand()
        {
            await HttpHelper.Instance.PostAsync("match/cancel", "");
            await LoadAsync();
        }

        private async Task DoEndMatchCommand()
        {
            await HttpHelper.Instance.PostAsync("match/end","");
            await LoadAsync();
        }

        public async Task LoadAsync()
        {
            var flics = await HttpHelper.Instance.GetListAsync<Flic>("flics");
            SetValue(() => FlicCount, flics.Count);

            var match = await HttpHelper.Instance.GetAsync<Match>("match");
            SetValue(() => Match, match);
            SetValue(() => MatchIsActive, match != null);

            if (!MatchIsActive)
            {
                var players = await HttpHelper.Instance.GetListAsync<Player>("players");
                SetValue(() => Players, players.Select(p => new MatchPlayersViewModel(p)).ToList());
            }
        }
    }
}
