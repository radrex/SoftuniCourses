namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        //----------------- Constants --------------------
        private const double DefaultFuelConsumption = 8.0;

        //---------------- Constructors ------------------
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        //----------------- Properties -------------------
        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
