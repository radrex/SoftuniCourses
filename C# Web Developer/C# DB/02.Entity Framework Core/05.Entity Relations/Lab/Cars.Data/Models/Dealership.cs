namespace Cars.Data.Models
{
    using System.Collections.Generic;

    public class Dealership
    {
        //--------------- Properties ----------------
        public int Id { get; set; }
        public string Name { get; set; }

        //--------------- Collections ---------------
        //-------- Car -------- [FK]
        public ICollection<CarDealership> CarsDealerships { get; set; } = new HashSet<CarDealership>();

    }
}
