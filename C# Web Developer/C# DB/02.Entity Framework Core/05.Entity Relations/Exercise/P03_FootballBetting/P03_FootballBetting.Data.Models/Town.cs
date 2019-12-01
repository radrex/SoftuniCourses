namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Town
    {
        //------------ Properties -------------
        public int TownId { get; set; }
        public string Name { get; set; }

        //------ Country ----- [FK]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        //------ Teams ----- [FK]
        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}
