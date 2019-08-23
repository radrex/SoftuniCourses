namespace P05_AverageNumber
{
    using System;

    class P05_AverageNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine($"{(double)sum / n:F2}");
        }
    }
}
