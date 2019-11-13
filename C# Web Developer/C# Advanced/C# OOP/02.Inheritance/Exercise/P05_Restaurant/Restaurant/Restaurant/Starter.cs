namespace Restaurant
{
    public abstract class Starter : Food
    {
        //------------------- Constructors ---------------------
        protected Starter(string name, decimal price, double grams) : base(name, price, grams)
        {

        }
    }
}
