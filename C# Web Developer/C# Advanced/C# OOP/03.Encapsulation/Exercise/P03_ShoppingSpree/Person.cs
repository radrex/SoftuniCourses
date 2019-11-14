namespace P03_ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        //-----------Fields------------
        private string name;
        private decimal money;
        private List<Product> products;

        //--------Constructors---------
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        //---------Properties----------
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
        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public List<Product> Products
        {
            get { return this.products; }
        }
        //-----------Methods-----------
        public void AddProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
                return;
            }
            products.Add(product);
            this.Money -= product.Cost;
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }
        public override string ToString()
        {
            if (this.Products.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {
                return $"{this.Name} - {String.Join(", ", this.Products.Select(p => p.Name))}";
            }
        }
    }
}
