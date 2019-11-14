namespace P04_PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        //------------Fields--------------
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        //---------Constructors-----------
        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }
        //----------Properties------------
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }
        public List<Topping> Toppings
        {
            get { return this.toppings; }
            private set { this.toppings = value; }
        }
        //------------Methods-------------
        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count > 9)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.Toppings.Add(topping);
        }

        private double Calories()
        {
            return this.Dough.Calories + this.Toppings.Sum(t => t.Calories);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Calories():F2} Calories.";
        }
    }
}
