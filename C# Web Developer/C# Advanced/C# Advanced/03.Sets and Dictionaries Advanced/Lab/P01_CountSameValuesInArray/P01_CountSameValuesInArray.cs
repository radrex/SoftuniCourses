namespace P01_CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P01_CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();
            double[] nums = Console.ReadLine()
                                   .Split()
                                   .Select(double.Parse)
                                   .ToArray();

            foreach (double num in nums)
            {
                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 1);
                }
                else
                {
                    numbers[num]++;
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
