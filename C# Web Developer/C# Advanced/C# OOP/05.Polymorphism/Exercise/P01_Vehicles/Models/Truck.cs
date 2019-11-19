namespace P01_Vehicles.Models
{
    public class Truck : Vehicle
    {
        //---------------- Fields ------------------
        private const double fuelConsumptionModifier = 1.6;

        //------------- Constructors ---------------
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += fuelConsumptionModifier;
        }

        //-------------- Properties ----------------

        //--------------- Methods ------------------
        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }
    }
}
