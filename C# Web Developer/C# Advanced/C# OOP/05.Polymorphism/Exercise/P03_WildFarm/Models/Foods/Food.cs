namespace P03_WildFarm.Models.Foods
{
    public abstract class Food
    {
        //------------- Constructors ---------------
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        //-------------- Properties ----------------
        public int Quantity { get; private set; }
    }
}
