namespace P03_WildFarm.Models.Animals
{
    using Models.Foods;
    using System;
    using System.Collections.Generic;

    public class Tiger : Feline
    {
        //-------------- Constants -----------------
        private const double TigerWeightMultiplier = 1.00;

        //------------- Constructors ---------------
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AllowedFoods = new List<Type>
            {
                typeof(Meat)
            };
        }

        //-------------- Properties ----------------
        protected override double WeightMultiplier => TigerWeightMultiplier;

        protected override ICollection<Type> AllowedFoods { get; }

        //--------------- Methods ------------------
        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
