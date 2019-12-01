namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Team
    {
        //------------ Properties -------------
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Initials { get; set; }
        public decimal Budget { get; set; }

        //-------- Color ------ [FK]
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        //-------- Town ------- [FK]
        public int TownId { get; set; }
        public Town Town { get; set; }

        //------ Players ----- [FK]
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        //------- Games ------ [FK]
        public ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();
        public ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();
    }
}
