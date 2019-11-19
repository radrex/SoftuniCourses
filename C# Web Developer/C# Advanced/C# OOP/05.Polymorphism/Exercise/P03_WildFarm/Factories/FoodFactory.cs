namespace P03_WildFarm.Factories
{
    using Models.Foods;
    using System;

    public class FoodFactory
    {
        //------------- Constructors ---------------
        public FoodFactory() { }

        //--------------- Methods ------------------
        public Food CreateFood(string type, params string[] args)
        {
            switch (type)
            {
                case "Fruit":       return new Fruit(int.Parse(args[1]));
                case "Meat":        return new Meat(int.Parse(args[1]));
                case "Seeds":       return new Seeds(int.Parse(args[1]));
                case "Vegetable":   return new Vegetable(int.Parse(args[1]));
                default:            throw new ArgumentException("Invalid food type.");
            }
        }
    }
}
