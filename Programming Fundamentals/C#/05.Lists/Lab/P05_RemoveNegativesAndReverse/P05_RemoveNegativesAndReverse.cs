namespace P05_RemoveNegativesAndReverse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P05_RemoveNegativesAndReverse
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            numbers.RemoveAll(n => n < 0);
            numbers.Reverse();

            Console.WriteLine(numbers.Count == 0 ? "empty" : String.Join(" ", numbers));
        }
    }
}