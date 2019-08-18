namespace P03_RoundingNumbers
{
    using System;
    using System.Linq;

    class P03_RoundingNumbers
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                                   .Split()
                                   .Select(double.Parse)
                                   .ToArray();

            foreach (double num in nums)
            {
                Console.WriteLine($"{num} => {Math.Round(num, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}