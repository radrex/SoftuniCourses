namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        //-------------------- Constants -----------------------
        private const double CoffeeMilliliters = 50.0;
        private const decimal CoffeePrice = 3.50M;

        //------------------- Constructors ---------------------
        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        //-------------------- Properties ----------------------
        public double Caffeine { get; private set; }
    }
}
