namespace P03_WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Models.Foods;

    public class Cat : Feline
    {
        //-------------- Constants -----------------
        private const double CatWeightMultiplier = 0.30;

        //------------- Constructors ---------------
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Vegetable),
                typeof(Meat)
            };
        }

        //-------------- Properties ----------------
        protected override double WeightMultiplier => CatWeightMultiplier;

        protected override ICollection<Type> AllowedFoods { get; }

        //--------------- Methods ------------------
        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
