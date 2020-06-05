namespace P02_PrintNumbersInReverseOrder
{
    using System;

    class P02_PrintNumbersInReverseOrder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                numbers[i] = num;
            }

            Array.Reverse(numbers);
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}