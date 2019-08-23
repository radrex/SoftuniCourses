namespace P03_Flowers
{
    using System;

    class P03_Flowers
    {
        static void Main(string[] args)
        {
            int chrysanthemums = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char holidaySign = char.Parse(Console.ReadLine());

            decimal chrysanthemumPrice = 0.0M;
            decimal rosePrice = 0.0M;
            decimal tulipPrice = 0.0M;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    chrysanthemumPrice = 2.00M;
                    rosePrice = 4.10M;
                    tulipPrice = 2.50M;
                    break;

                case "Autumn":
                case "Winter":
                    chrysanthemumPrice = 3.75M;
                    rosePrice = 4.50M;
                    tulipPrice = 4.15M;
                    break;
            }

            if (holidaySign == 'Y')
            {
                chrysanthemumPrice *= 1.15M;
                rosePrice *= 1.15M;
                tulipPrice *= 1.15M;
            }

            decimal bouquetPrice = chrysanthemums * chrysanthemumPrice + roses * rosePrice + tulips * tulipPrice;
            if (tulips > 7 && season == "Spring")
            {
                bouquetPrice *= 0.95M;
            }

            if (roses >= 10 && season == "Winter")
            {
                bouquetPrice *= 0.90M;
            }

            if (chrysanthemums + roses + tulips > 20)
            {
                bouquetPrice *= 0.80M;
            }

            bouquetPrice += 2.00M;
            Console.WriteLine($"{bouquetPrice:F2}");
        }
    }
}
