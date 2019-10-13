namespace P04_FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P04_FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();
            Predicate<int> filter;
            Action<Queue<int>> printer = PrintQueue;

            string command = Console.ReadLine();
            switch (command)
            {
                case "odd":     filter = number => number % 2 != 0;  break;
                case "even":    filter = number => number % 2 == 0;  break;
                default:        filter = null;                       break;
            }

            Queue<int> nums = GetNumbers(bounds[0], bounds[1], filter);
            printer(nums);
        }

        public static Queue<int> GetNumbers(int lowerBound, int upperBound, Predicate<int> filter)
        {
            Queue<int> numbers = new Queue<int>();
            while (lowerBound <= upperBound)
            {
                if (filter(lowerBound))
                {
                    numbers.Enqueue(lowerBound);
                }
                lowerBound++;
            }
            return numbers;
        }

        public static void PrintQueue(Queue<int> collection)
        {
            Console.WriteLine(String.Join(" ", collection));
        }
    }
}
