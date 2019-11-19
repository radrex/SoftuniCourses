namespace P01_Vehicles.Models
{
    public class Car : Vehicle
    {
        //---------------- Fields ------------------
        private const double fuelConsumptionModifier = 0.9;

        //------------- Constructors ---------------
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += fuelConsumptionModifier;
        }

        //-------------- Properties ----------------
    }
}
