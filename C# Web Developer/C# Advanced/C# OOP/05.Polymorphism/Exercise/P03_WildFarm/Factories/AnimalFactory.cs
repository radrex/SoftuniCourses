namespace P03_WildFarm.Factories
{
    using Models.Animals;
    using System;

    public class AnimalFactory
    {
        //------------- Constructors ---------------
        public AnimalFactory() {}

        //--------------- Methods ------------------
        public Animal CreateAnimal(string type, params string[] args)
        {
            switch (type)
            {
                case "Owl":     return new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
                case "Hen":     return new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
                case "Mouse":   return new Mouse(args[1], double.Parse(args[2]), args[3]);
                case "Dog":     return new Dog(args[1], double.Parse(args[2]), args[3]);
                case "Cat":     return new Cat(args[1], double.Parse(args[2]), args[3], args[4]);
                case "Tiger":   return new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);
                default:        throw new ArgumentException("Invalid animal type.");
            }
        }
    }
}
