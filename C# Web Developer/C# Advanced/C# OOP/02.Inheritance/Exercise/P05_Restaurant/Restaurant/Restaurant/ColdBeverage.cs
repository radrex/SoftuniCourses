namespace Restaurant
{
    public abstract class ColdBeverage : Beverage
    {
        //------------------- Constructors ---------------------
        protected ColdBeverage(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {

        }
    }
}
