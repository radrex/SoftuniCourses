namespace Restaurant
{
    public abstract class Beverage : Product
    {
        //------------------- Constructors ---------------------
        protected Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            this.Milliliters = milliliters;
        }

        //-------------------- Properties ----------------------
        public double Milliliters { get; private set; }
    }
}
