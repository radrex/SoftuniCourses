namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Position
    {
        //------------ Properties -------------
        public int PositionId { get; set; }
        public string Name { get; set; }

        //------ Players ----- [FK]
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
