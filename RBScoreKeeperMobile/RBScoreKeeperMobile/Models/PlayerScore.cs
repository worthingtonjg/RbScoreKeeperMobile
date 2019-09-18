using System;
using System.Collections.Generic;
using System.Text;

namespace RBScoreKeeperMobile.Models
{
    public class PlayerScore
    {
        public Guid ScoreId { get; set; }

        public Guid PlayerId { get; set; }

        public int Score { get; set; }
    }
}
