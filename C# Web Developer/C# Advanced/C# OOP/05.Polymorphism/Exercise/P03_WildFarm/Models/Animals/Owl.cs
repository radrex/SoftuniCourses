namespace P03_WildFarm.Models.Animals
{
    using Models.Foods;
    using System;
    using System.Collections.Generic;

    public class Owl : Bird
    {
        //-------------- Constants -----------------
        private const double OwlWeightMultiplier = 0.25;

        //------------- Constructors ---------------
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Meat)
            };
        }

        //-------------- Properties ----------------
        protected override double WeightMultiplier => OwlWeightMultiplier;

        protected override ICollection<Type> AllowedFoods { get; }

        //--------------- Methods ------------------
        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
