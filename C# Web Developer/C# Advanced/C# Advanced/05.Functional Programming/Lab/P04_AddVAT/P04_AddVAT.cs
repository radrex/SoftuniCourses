namespace P04_AddVAT
{
    using System;
    using System.Linq;

    class P04_AddVAT
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(double.Parse)
                              .Select(number => number * 1.20)
                              .ToList()
                              .ForEach(number => Console.WriteLine($"{number:F2}"));
        }
    }
}
