namespace P03_SalesDatabase
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new SalesContext();
            context.Database.Migrate();
            Seed(context);
        }
        private static void Seed(SalesContext context)
        {
            Product[] products = new[]
            {
                new Product
                {
                    Name = "Chips",
                    Quantity = 30,
                    Price = 1.20M,
                    Description = "Delicious baked chips",
                },
                new Product
                {
                    Name = "Water",
                    Quantity = 110,
                    Price = 1.00M,
                    Description = "Purest mountain water",
                }
            };
            context.Products.AddRange(products);

            Customer[] customers = new[]
            {
                new Customer
                {
                    Name = "Ivan",
                    CreditCardNumber = "1111 1111 1111 1111"
                },
                new Customer
                {
                    Name = "Mariya",
                    CreditCardNumber = "0000 1111 1111 1111"
                }
            };
            context.Customers.AddRange(customers);

            Store store = new Store
            {
                Name = "MegaShop"
            };
            context.Stores.Add(store);

            Sale[] sales = new Sale[]
            {
                new Sale
                {
                    Date = new DateTime(2019, 11, 6),
                    Product = products[0],
                    Customer = customers[1],
                    Store = store,
                },
                new Sale
                {
                    Date = new DateTime(2019, 11, 6),
                    Product = products[0],
                    Customer = customers[0],
                    Store = store,
                },
                new Sale
                {
                    Date = new DateTime(2019, 11, 6),
                    Product = products[1],
                    Customer = customers[0],
                    Store = store,
                }
            };
            context.Sales.AddRange(sales);

            context.SaveChanges();
        }
    }
}
