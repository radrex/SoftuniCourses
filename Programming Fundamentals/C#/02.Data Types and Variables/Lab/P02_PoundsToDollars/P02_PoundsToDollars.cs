namespace P02_PoundsToDollars
{
    using System;

    class P02_PoundsToDollars
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal dollars = pounds * 1.31M;

            Console.WriteLine($"{dollars:F3}");
        }
    }
}