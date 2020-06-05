namespace P04_Orders
{
    using System;
    using System.Collections.Generic;

    class P04_Orders
    {
        static void Main(string[] args)
        {
            Dictionary<string, Tuple<decimal, int>> products = new Dictionary<string, Tuple<decimal, int>>();

            string[] productData = Console.ReadLine().Split();
            while (productData[0] != "buy")
            {
                string product = productData[0];
                decimal price = decimal.Parse(productData[1]);
                int quantity = int.Parse(productData[2]);

                if (!products.ContainsKey(product))
                {
                    products.Add(product, new Tuple<decimal, int>(price, quantity));
                }
                else
                {
                    int oldQuantity = products[product].Item2;
                    products[product] = new Tuple<decimal, int>(price, oldQuantity + quantity);
                }

                productData = Console.ReadLine().Split();
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.Item1 * product.Value.Item2:F2}");
            }
        }
    }
}