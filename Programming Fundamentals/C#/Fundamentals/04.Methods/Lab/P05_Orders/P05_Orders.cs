namespace P05_Orders
{
    using System;

    class P05_Orders
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            PrintBill(product, quantity);
        }

        public static void PrintBill(string product, int quantity)
        {
            double bill = 0.0;
            switch (product)
            {
                case "coffee":
                    bill = quantity * 1.50;
                    break;

                case "water":
                    bill = quantity * 1.00;
                    break;

                case "coke":
                    bill = quantity * 1.40;
                    break;

                case "snacks":
                    bill = quantity * 2.00;
                    break;
            }

            Console.WriteLine($"{bill:F2}");
        }
    }
}