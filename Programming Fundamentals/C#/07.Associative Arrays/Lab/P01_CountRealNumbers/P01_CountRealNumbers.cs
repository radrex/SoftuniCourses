namespace P01_CountRealNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P01_CountRealNumbers
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                                      .Split()
                                      .Select(double.Parse)
                                      .ToArray();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (double number in numbers)
            {
                if (!counts.ContainsKey(number))
                {
                    counts.Add(number, 0);
                }

                counts[number]++;
            }

            foreach (KeyValuePair<double, int> kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}