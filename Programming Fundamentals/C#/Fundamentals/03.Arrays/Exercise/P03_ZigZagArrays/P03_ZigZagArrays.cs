namespace P03_ZigZagArrays
{
    using System;
    using System.Linq;

    class P03_ZigZagArrays
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            for (int i = 1; i <= n; i++)
            {
                int[] currentArray = Console.ReadLine()
                                            .Split()
                                            .Select(int.Parse)
                                            .ToArray();

                if (i % 2 != 0)   // odds
                {
                    arr1[i - 1] = currentArray[0];
                    arr2[i - 1] = currentArray[1];
                }
                else  // evens
                {
                    arr1[i - 1] = currentArray[1];
                    arr2[i - 1] = currentArray[0];
                }
            }

            Console.WriteLine(String.Join(" ", arr1));
            Console.WriteLine(String.Join(" ", arr2));
        }
    }
}