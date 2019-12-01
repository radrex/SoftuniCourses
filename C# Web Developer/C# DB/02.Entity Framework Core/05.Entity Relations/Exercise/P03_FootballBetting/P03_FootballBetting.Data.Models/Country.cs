namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Country
    {
        //------------ Properties -------------
        public int CountryId { get; set; }
        public string Name { get; set; }

        //------ Towns ----- [FK]
        public ICollection<Town> Towns { get; set; } = new HashSet<Town>();
    }
}
