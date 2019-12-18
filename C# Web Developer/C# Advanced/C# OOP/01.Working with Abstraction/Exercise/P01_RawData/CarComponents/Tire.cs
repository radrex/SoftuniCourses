namespace P01_RawData.CarComponents
{
    public class Tire
    {
        //-------------- Constructors ----------------
        public Tire(double pressure, int age)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        //--------------- Properties -----------------
        public int Age { get; private set; }
        public double Pressure { get; private set; }
    }
}
