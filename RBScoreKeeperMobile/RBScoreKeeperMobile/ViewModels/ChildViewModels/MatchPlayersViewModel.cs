using RBScoreKeeperMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBScoreKeeperMobile.ViewModels.ChildViewModels
{
    public class MatchPlayersViewModel : BaseViewModel
    {
        private Player _player;

        public bool Selected { get; set; }

        public Guid Id
        {
            get { return _player.PlayerId; }
        }

        public string Name
        {
            get { return _player.Name; }
        }

        public MatchPlayersViewModel(Player player)
        {
            _player = player;
        }
    }
}
