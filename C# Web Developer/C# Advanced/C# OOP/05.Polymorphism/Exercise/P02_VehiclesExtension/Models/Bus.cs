namespace P02_VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        //---------------- Fields ------------------
        private const double fuelConsumptionModifier = 1.4;

        //------------- Constructors ---------------
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += fuelConsumptionModifier;
        }
    }
}
