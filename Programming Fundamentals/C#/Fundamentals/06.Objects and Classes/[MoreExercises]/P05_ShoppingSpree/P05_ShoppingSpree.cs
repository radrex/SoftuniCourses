namespace P05_ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P05_ShoppingSpree
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            for (int i = 1; i <= 2; i++)
            {
                string[] tokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (string token in tokens)
                {
                    string[] data = token.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    if (i == 1)
                    {
                        string name = data[0];
                        decimal money = decimal.Parse(data[1]);
                        Person person = new Person()
                        {
                            Name = name,
                            Money = money
                        };
                        people.Add(person);
                    }
                    else if (i == 2)
                    {
                        string productName = data[0];
                        decimal productPrice = decimal.Parse(data[1]);
                        Product product = new Product()
                        {
                            Name = productName,
                            Price = productPrice
                        };
                        products.Add(product);
                    }
                }
            }

            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                Person currentPerson = people.First(p => p.Name == command[0]);
                Product currentProduct = products.First(p => p.Name == command[1]);

                if (currentPerson.Money >= currentProduct.Price)
                {
                    currentPerson.Money -= currentProduct.Price;
                    currentPerson.Products.Add(currentProduct);
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                }

                command = Console.ReadLine().Split();
            }

            foreach (Person person in people)
            {
                if (person.Products.Count > 0)
                {
                    List<string> productNames = new List<string>();
                    foreach (Product product in person.Products)
                    {
                        productNames.Add(product.Name);
                    }

                    Console.WriteLine($"{person.Name} - {String.Join(", ", productNames)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public Person()
        {
            this.Products = new List<Product>();
        }

        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<Product> Products { get; set; }
    }

    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}