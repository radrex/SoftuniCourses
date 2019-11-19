namespace P02_VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        //---------------- Fields ------------------
        private const double fuelConsumptionModifier = 0.9;

        //------------- Constructors ---------------
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += fuelConsumptionModifier;
        }
    }
}
