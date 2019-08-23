namespace P04_VegetableMarket
{
    using System;

    class P04_VegetableMarket
    {
        static void Main(string[] args)
        {
            double vegiesPricePerKg = double.Parse(Console.ReadLine());
            double fruitsPricePerKg = double.Parse(Console.ReadLine());
            double vegiesKg = double.Parse(Console.ReadLine());
            double fruitsKg = double.Parse(Console.ReadLine());

            double vegiesTotalPrice = vegiesPricePerKg * vegiesKg;
            double fruitsTotalPrice = fruitsPricePerKg * fruitsKg;

            double totalSum = (vegiesTotalPrice + fruitsTotalPrice) / 1.94;
            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
