namespace Restaurant
{
    public abstract class MainDish : Food
    {
        //------------------- Constructors ---------------------
        protected MainDish(string name, decimal price, double grams) : base(name, price, grams)
        {

        }
    }
}
