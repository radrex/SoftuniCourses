namespace P03_WildFarm.Models.Animals
{
    public abstract class Feline : Mammal
    {
        //------------- Constructors ---------------
        protected Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        //-------------- Properties ----------------
        public string Breed { get; private set; }

        //--------------- Methods ------------------
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
