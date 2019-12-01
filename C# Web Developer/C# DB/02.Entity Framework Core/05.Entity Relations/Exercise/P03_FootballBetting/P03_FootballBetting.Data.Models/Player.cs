namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Player
    {
        //------------ Properties -------------
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int SquadNumber { get; set; }
        public bool IsInjured { get; set; }

        //-------- Team ------- [FK]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        //------ Position ----- [FK]
        public int PositionId { get; set; }
        public Position Position { get; set; }

        //------ PlayerStatistics ----- [FK]
        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}
