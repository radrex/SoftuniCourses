namespace P01_USDtoBGN
{
    using System;

    class P01_USDtoBGN
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double bgn = Math.Round(usd * 1.79549, 2);

            Console.WriteLine($"{bgn}");
        }
    }
}
