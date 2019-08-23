namespace P05_Vacation
{
    using System;

    class P05_Vacation
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string place = string.Empty;
            string location = string.Empty;
            decimal price = 0.0M;

            if (budget <= 1000)
            {
                place = "Camp";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        price = budget * 0.65M;
                        break;

                    case "Winter":
                        location = "Morocco";
                        price = budget * 0.45M;
                        break;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                place = "Hut";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        price = budget * 0.80M;
                        break;

                    case "Winter":
                        location = "Morocco";
                        price = budget * 0.60M;
                        break;
                }
            }
            else if (budget > 3000)
            {
                place = "Hotel";
                switch (season)
                {
                    case "Summer":
                        location = "Alaska";
                        break;

                    case "Winter":
                        location = "Morocco";
                        break;
                }

                price = budget * 0.90M;
            }

            Console.WriteLine($"{location} - {place} - {price:F2}");
        }
    }
}
