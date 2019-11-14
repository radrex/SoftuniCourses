namespace P03_ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] personTokens = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < personTokens.Length; i += 2)
            {
                string name = personTokens[i];
                decimal money = decimal.Parse(personTokens[i + 1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            List<Product> products = new List<Product>();
            string[] productTokens = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productTokens.Length; i += 2)
            {
                string givenProduct = productTokens[i];
                decimal cost = decimal.Parse(productTokens[i + 1]);
                try
                {
                    Product product = new Product(givenProduct, cost);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            string[] order = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (order[0] != "END")
            {
                string name = order[0];
                string orderedProduct = order[1];

                Product product = products.FirstOrDefault(p => p.Name == orderedProduct);
                people.FirstOrDefault(p => p.Name == name).AddProduct(product);

                order = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
