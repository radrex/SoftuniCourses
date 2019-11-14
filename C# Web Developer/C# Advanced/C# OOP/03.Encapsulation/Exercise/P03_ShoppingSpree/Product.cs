namespace P03_ShoppingSpree
{
    using System;

    public class Product
    {
        //----------Fields------------
        private string name;
        private decimal cost;

        //-------Constructors---------
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        //--------Properties----------
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get { return this.cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }
        //----------Methods-----------
        public override string ToString()
        {
            return this.Name;
        }
    }
}
