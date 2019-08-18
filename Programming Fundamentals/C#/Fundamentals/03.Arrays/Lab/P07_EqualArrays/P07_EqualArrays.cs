namespace P07_EqualArrays
{
    using System;
    using System.Linq;

    class P07_EqualArrays
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            int[] arr2 = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            if (arr1.Length != arr2.Length)
            {
                Console.WriteLine("Arrays are not identical.");
            }

            int sum = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
                else
                {
                    sum += arr1[i];
                }
            }

            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}