namespace P03_WildFarm.Models.Animals
{
    using Models.Foods;
    using System;
    using System.Collections.Generic;

    public class Dog : Mammal
    {
        //-------------- Constants -----------------
        private const double DogWeightMultiplier = 0.40;

        //------------- Constructors ---------------
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Meat)
            };
        }

        //-------------- Properties ----------------
        protected override double WeightMultiplier => DogWeightMultiplier;

        protected override ICollection<Type> AllowedFoods { get; }

        //--------------- Methods ------------------
        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
