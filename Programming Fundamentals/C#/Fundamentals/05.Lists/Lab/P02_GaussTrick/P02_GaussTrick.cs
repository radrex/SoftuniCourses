namespace P02_GaussTrick
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_GaussTrick
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            int iterations = numbers.Count / 2;
            for (int i = 0; i < iterations; i++)
            {
                numbers[i] = numbers[i] + numbers.Last();
                numbers.RemoveAt(numbers.Count - 1);
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}