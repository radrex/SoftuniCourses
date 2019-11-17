namespace Animals
{
    public class Animal
    {
        //------------------- Constructors ---------------------
        protected Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        //-------------------- Properties ----------------------
        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }

        //--------------------- Methods ------------------------
        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my favourite food is {this.FavouriteFood}";
        }
    }
}
