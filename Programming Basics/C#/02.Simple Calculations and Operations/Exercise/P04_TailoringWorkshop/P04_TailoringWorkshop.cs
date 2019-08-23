namespace P04_TailoringWorkshop
{
    using System;

    class P04_TailoringWorkshop
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double coversArea = tables * (length + 2.0 * 0.30) * (width + 2.0 * 0.30);
            double squaresArea = tables * (length / 2.0) * (length / 2.0);

            double usd = coversArea * 7.0 + squaresArea * 9.0;
            double bgn = usd * 1.85;

            Console.WriteLine($"{usd:F2} USD");
            Console.WriteLine($"{bgn:F2} BGN");
        }
    }
}
