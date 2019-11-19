namespace P03_WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        //------------- Constructors ---------------
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        //-------------- Properties ----------------
        public double WingSize { get; private set; }

        //--------------- Methods ------------------
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
