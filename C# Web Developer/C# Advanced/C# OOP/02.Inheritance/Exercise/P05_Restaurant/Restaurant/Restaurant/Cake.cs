namespace Restaurant
{
    public class Cake : Dessert
    {
        //-------------------- Constants -----------------------
        private const double CakeGrams = 250.0;
        private const double CakeCalories = 1000.0;
        private const decimal CakePrice = 5.0M;

        //------------------- Constructors ---------------------
        public Cake(string name) : base(name, CakePrice, CakeGrams, CakeCalories)
        {

        }
    }
}
