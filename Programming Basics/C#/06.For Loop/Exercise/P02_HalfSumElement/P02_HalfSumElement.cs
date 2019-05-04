namespace P02_HalfSumElement
{
    using System;

    class P02_HalfSumElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                sum += num;
                if (num > max)
                {
                    max = num;
                }
            }

            if (sum - max == max)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {sum - max}");
            }
            else
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {Math.Abs(max - (sum - max))}");
            }
        }
    }
}
