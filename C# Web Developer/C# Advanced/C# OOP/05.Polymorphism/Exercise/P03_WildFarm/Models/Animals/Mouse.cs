namespace P03_WildFarm.Models.Animals
{
    using Models.Foods;
    using System;
    using System.Collections.Generic;

    public class Mouse : Mammal
    {
        //-------------- Constants -----------------
        private const double MouseWeightMultiplier = 0.10;

        //------------- Constructors ---------------
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit)
            };
        }

        //-------------- Properties ----------------
        protected override double WeightMultiplier => MouseWeightMultiplier;

        protected override ICollection<Type> AllowedFoods { get; }

        //--------------- Methods ------------------
        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
