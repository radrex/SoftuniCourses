namespace P03_WildFarm.Models.Animals
{
    using Models.Foods;
    using System;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        //-------------- Constants -----------------
        private const double HenWeightMultiplier = 0.35;

        //------------- Constructors ---------------
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit),
                typeof(Meat),
                typeof(Seeds)
            };
        }

        //-------------- Properties ----------------
        protected override double WeightMultiplier => HenWeightMultiplier;

        protected override ICollection<Type> AllowedFoods { get; }

        //--------------- Methods ------------------
        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
