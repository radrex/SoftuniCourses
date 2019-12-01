namespace P03_FootballBetting.Data.Models
{
    using Enums;
    using System;

    public class Bet
    {
        //------------ Properties -------------
        public int BetId { get; set; }
        public decimal Amount { get; set; }
        public Prediction Prediction { get; set; }
        public DateTime DateTime { get; set; }

        //-------- User ------- [FK]
        public int UserId { get; set; }
        public User User { get; set; }

        //-------- Game ------- [FK]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
