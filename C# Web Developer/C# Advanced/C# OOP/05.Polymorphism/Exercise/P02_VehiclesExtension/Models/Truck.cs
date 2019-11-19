namespace P02_VehiclesExtension.Models
{
    using System;

    public class Truck : Vehicle
    {
        //---------------- Fields ------------------
        private const double fuelConsumptionModifier = 1.6;

        //------------- Constructors ---------------
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += fuelConsumptionModifier;
        }

        //--------------- Methods ------------------
        public override void Refuel(double fuel)
        {
            if (fuel > this.TankCapacity - this.FuelQuantity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            base.Refuel(fuel * 0.95);
        }
    }
}
