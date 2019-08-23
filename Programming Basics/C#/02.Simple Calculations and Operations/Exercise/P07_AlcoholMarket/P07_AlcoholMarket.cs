namespace P07_AlcoholMarket
{
    using System;

    class P07_AlcoholMarket
    {
        static void Main(string[] args)
        {
            double whiskyPrice = double.Parse(Console.ReadLine());
            double beerLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double rakiaLiters = double.Parse(Console.ReadLine());
            double whiskyLiters = double.Parse(Console.ReadLine());

            double rakiaPrice = whiskyPrice * 0.5;
            double winePrice = rakiaPrice * 0.6;
            double beerPrice = rakiaPrice * 0.2;

            double rakiaSum = rakiaLiters * rakiaPrice;
            double wineSum = wineLiters * winePrice;
            double beerSum = beerLiters * beerPrice;
            double whiskySum = whiskyLiters * whiskyPrice;

            double totalAmount = rakiaSum + wineSum + beerSum + whiskySum;
            Console.WriteLine($"{totalAmount:F2}");
        }
    }
}
