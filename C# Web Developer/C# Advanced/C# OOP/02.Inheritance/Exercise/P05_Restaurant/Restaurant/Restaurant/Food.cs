namespace Restaurant
{
    public abstract class Food : Product
    {
        //------------------- Constructors ---------------------
        protected Food(string name, decimal price, double grams) : base(name, price)
        {
            this.Grams = grams;
        }

        //-------------------- Properties ----------------------
        public double Grams { get; private set; }
    }
}
