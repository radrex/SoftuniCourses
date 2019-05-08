namespace P03_Harvest
{
    using System;

    class P03_Harvest
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapePerSquareM = double.Parse(Console.ReadLine());
            int requiredLitersWine = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grapesForWine = (grapePerSquareM * area) * 0.40;
            double wineLiters = grapesForWine / 2.5;

            if (wineLiters < requiredLitersWine)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(requiredLitersWine - wineLiters)} liters wine needed.");
            }
            else
            {
                double wineLeft = wineLiters - requiredLitersWine;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineLiters)} liters.");
                Console.WriteLine($"{Math.Ceiling(wineLeft)} liters left -> {Math.Ceiling(wineLeft / workers)} liters per person.");
            }
        }
    }
}
