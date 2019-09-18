using System;
using System.Collections.Generic;
using System.Linq;

namespace RBScoreKeeperMobile.Models
{
    public class Match
    {
        public Guid MatchId { get; set; }

        public List<Player> Players { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public List<Game> Games { get; set; }

        public Game CurrentGame
        {
            get
            {
                return Games.LastOrDefault();
            }
        }
    }
}
