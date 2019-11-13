namespace Restaurant
{
    public abstract class Dessert : Food
    {
        //------------------- Constructors ---------------------
        protected Dessert(string name, decimal price, double grams, double calories) : base(name, price, grams)
        {
            this.Calories = calories;
        }

        //-------------------- Properties ----------------------
        public double Calories { get; private set; }
    }
}
