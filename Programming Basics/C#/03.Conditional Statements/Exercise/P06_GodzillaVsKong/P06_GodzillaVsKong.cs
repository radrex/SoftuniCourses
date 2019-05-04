namespace P06_GodzillaVsKong
{
    using System;

    class P06_GodzillaVsKong
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());

            double decorSum = budged * 0.1;
            double clothingSum = 0.0;

            if (statists > 150)
            {
                clothingSum = (statists * clothingPrice) * 0.9;
            }
            else
            {
                clothingSum = statists * clothingPrice;
            }

            double movieSum = decorSum + clothingSum;
            if (movieSum > budged)
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {movieSum - budged:F2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budged - movieSum:F2} leva left.");
            }
        }
    }
}
