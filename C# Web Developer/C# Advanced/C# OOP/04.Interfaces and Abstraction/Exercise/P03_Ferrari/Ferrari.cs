namespace P03_Ferrari
{
    public class Ferrari : IDriveable
    {
        //----------- Constructors -------------
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        //------------ Properties --------------
        public string Driver { get; private set; }
        public string Model => "488-Spider";

        //------------- Methods ----------------
        public string Brake()
        {
            return $"Brakes!";
        }

        public string Gas()
        {
            return $"Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brake()}/{this.Gas()}/{this.Driver}";
        }
    }
}
