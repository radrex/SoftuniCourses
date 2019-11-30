namespace Cars.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;

    public class Car
    {
        //--------------- Properties ----------------
        public int Id { get; set; }
        public string Model { get; set; }
        public int Doors { get; set; }
        public Transmission Transmission { get; set; }
        public DateTime ProductionYear { get; set; }

        //-------- Engine -------- [FK]
        public int EngineId { get; set; }
        public Engine Engine { get; set; }

        //-------- Make ---------- [FK]
        public int MakeId { get; set; }
        public Make Make { get; set; }

        //---- LicensePlate ------ [FK]
        public int? LicensePlateId { get; set; }
        public LicensePlate LicensePlate { get; set; }

        //--------------- Collections ---------------
        public ICollection<CarDealership> CarsDealerships { get; set; } = new HashSet<CarDealership>();
    }
}
