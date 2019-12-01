namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        //------------ Properties -------------
        public int ScoredGoals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }

        //-------- Game ------- [FK]
        public int GameId { get; set; }
        public Game Game { get; set; }

        //------- Player ------ [FK]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
