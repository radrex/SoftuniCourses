namespace Cars.Data.Models
{
    using Enums;
    using System.Collections.Generic;

    public class Engine
    {
        //--------------- Properties ----------------
        public int Id { get; set; }
        public double Capacity { get; set; }
        public int Cyllinders { get; set; }
        public int HorsePower { get; set; }
        public FuelType FuelType { get; set; }

        //--------------- Collections ---------------
        //-------- Car -------- [FK]
        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
