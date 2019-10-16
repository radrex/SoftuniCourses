namespace P07_RawData
{
    public class Tire
    {
        //-------------- Constructors --------------
        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        //--------------- Properties ---------------
        public double Pressure { get; private set; }

        public int Age { get; private set; }
    }
}
