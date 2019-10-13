namespace P02_SumNumbers
{
    using System;
    using System.Linq;

    class P02_SumNumbers
    {
        static void Main(string[] args)
        {
            Action<int[]> action = Print;
            int[] numbers = Console.ReadLine()
                                   .Split(", ")
                                   .Select(int.Parse)
                                   .ToArray();
            action(numbers);
        }

        static void Print(int[] numbers)
        {
            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
