namespace P03_AccountBalance
{
    using System;

    class P03_AccountBalance
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int couter = 0;
            double balance = 0.0;

            while (couter < n)
            {
                double amount = double.Parse(Console.ReadLine());

                if (amount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                balance += amount;
                Console.WriteLine($"Increase: {amount:F2}");
                couter++;
            }

            Console.WriteLine($"Total: {balance:F2}");
        }
    }
}
