namespace Restaurant
{
    public abstract class Product
    {
        //------------------- Constructors ---------------------
        protected Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        //-------------------- Properties ----------------------
        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}
