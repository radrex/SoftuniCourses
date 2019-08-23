namespace P04_CarToGo
{
    using System;

    class P04_CarToGo
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string car = string.Empty;
            string carClass = string.Empty;
            decimal price = 0.0M;

            if (budget <= 100)
            {
                carClass = "Economy class";
                switch (season)
                {
                    case "Summer":
                        car = "Cabrio";
                        price = budget * 0.35M;
                        break;

                    case "Winter":
                        car = "Jeep";
                        price = budget * 0.65M;
                        break;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                carClass = "Compact class";
                switch (season)
                {
                    case "Summer":
                        car = "Cabrio";
                        price = budget * 0.45M;
                        break;

                    case "Winter":
                        car = "Jeep";
                        price = budget * 0.80M;
                        break;
                }
            }
            else if (budget > 500)
            {
                carClass = "Luxury class";
                car = "Jeep";
                price = budget * 0.90M;
            }

            Console.WriteLine(carClass);
            Console.WriteLine($"{car} - {price:F2}");
        }
    }
}
