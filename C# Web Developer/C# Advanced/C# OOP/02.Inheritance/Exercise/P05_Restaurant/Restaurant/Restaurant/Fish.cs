namespace Restaurant
{
    public class Fish : MainDish
    {
        //-------------------- Constants -----------------------
        private const double FishGrams = 22.0;

        //------------------- Constructors ---------------------
        public Fish(string name, decimal price) : base(name, price, FishGrams)
        {

        }
    }
}
