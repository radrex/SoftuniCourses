namespace NeedForSpeed
{
    public class SportCar : Car
    {
        //----------------- Constants --------------------
        private const double DefaultFuelConsumption = 10.0;

        //---------------- Constructors ------------------
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        //----------------- Properties -------------------
        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
