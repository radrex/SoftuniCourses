namespace P05_FishingBoat
{
    using System;

    class P05_FishingBoat
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            double price = 0.0;

            switch (season)
            {
                case "Spring":
                    price = 3000.0;

                    if (fishermen <= 6)
                    {
                        price *= 0.9;
                    }
                    else if (fishermen >= 7 && fishermen <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (fishermen >= 12)
                    {
                        price *= 0.75;
                    }

                    if (fishermen % 2 == 0)
                    {
                        price *= 0.95;
                    }
                    break;

                case "Summer":
                    price = 4200.0;

                    if (fishermen <= 6)
                    {
                        price *= 0.9;
                    }
                    else if (fishermen >= 7 && fishermen <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (fishermen >= 12)
                    {
                        price *= 0.75;
                    }

                    if (fishermen % 2 == 0)
                    {
                        price *= 0.95;
                    }
                    break;

                case "Autumn":
                    price = 4200.0;

                    if (fishermen <= 6)
                    {
                        price *= 0.9;
                    }
                    else if (fishermen >= 7 && fishermen <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (fishermen >= 12)
                    {
                        price *= 0.75;
                    }
                    break;

                case "Winter":
                    price = 2600.0;

                    if (fishermen <= 6)
                    {
                        price *= 0.9;
                    }
                    else if (fishermen >= 7 && fishermen <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (fishermen >= 12)
                    {
                        price *= 0.75;
                    }

                    if (fishermen % 2 == 0)
                    {
                        price *= 0.95;
                    }
                    break;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price - budget:F2} leva.");
            }
        }
    }
}
