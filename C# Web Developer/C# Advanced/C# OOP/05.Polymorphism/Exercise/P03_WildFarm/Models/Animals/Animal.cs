namespace P03_WildFarm.Models.Animals
{
    using Contracts;
    using Models.Foods;
    using System;
    using System.Collections.Generic;

    public abstract class Animal : ISoundProduceable, IEat
    {
        //------------- Constructors ---------------
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        //-------------- Properties ----------------
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }
        protected abstract ICollection<Type> AllowedFoods { get; }

        //--------------- Methods ------------------
        public abstract void ProduceSound();

        public void Eat(Food food)
        {
            if (!this.AllowedFoods.Contains(food.GetType()))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
