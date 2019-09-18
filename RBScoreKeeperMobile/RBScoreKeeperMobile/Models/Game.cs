using System;
using System.Collections.Generic;
using System.Text;

namespace RBScoreKeeperMobile.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<PlayerScore> Scores { get; set; }
    }
}
