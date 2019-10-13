namespace P03_CustomMinFunction
{
    using System;
    using System.Linq;

    class P03_CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> minFunction = GetMin;
            int[] numbers = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .ToArray();

            int minNumber = minFunction(numbers);
            Console.WriteLine(minNumber);
        }

        private static int GetMin(int[] array)
        {
            int min = int.MaxValue;
            foreach (int num in array)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }
    }
}
