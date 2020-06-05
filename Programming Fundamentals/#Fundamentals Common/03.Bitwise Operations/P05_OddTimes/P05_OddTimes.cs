namespace P05_OddTimes
{
    using System;
    using System.Linq;

    class P05_OddTimes
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split(' ')
                                   .Select(int.Parse)
                                   .ToArray();
            int result = 0;
            foreach (int num in numbers)
            {
                result = result ^ num;
            }

            Console.WriteLine(result);
        }
    }
}
