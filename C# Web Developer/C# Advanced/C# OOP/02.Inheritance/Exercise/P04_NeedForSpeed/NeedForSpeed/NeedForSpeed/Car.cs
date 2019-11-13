namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        //----------------- Constants --------------------
        private const double DefaultFuelConsumption = 3.0;

        //---------------- Constructors ------------------
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        //----------------- Properties -------------------
        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
