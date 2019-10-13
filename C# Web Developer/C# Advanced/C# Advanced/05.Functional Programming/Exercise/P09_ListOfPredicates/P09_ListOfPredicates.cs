namespace P09_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P09_ListOfPredicates
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .Distinct()
                                    .ToArray();

            Func<int, int, bool> filter = (x, y) => x % y == 0;
            Console.WriteLine(String.Join(" ", ExtractDivisibles(divisors, n, filter)));
        }

        private static Queue<int> ExtractDivisibles(int[] divisors, int n, Func<int, int, bool> filter)
        {
            Queue<int> numbers = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                bool isValid = true;
                foreach (int divisor in divisors)
                {
                    if (!filter(i, divisor))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    numbers.Enqueue(i);
                }
            }

            return numbers;
        }
    }
}
