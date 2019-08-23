namespace P01_MatchTickets
{
    using System;

    class P01_MatchTickets
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            decimal price = 0.0M;
            switch (category)
            {
                case "VIP":     price = people * 499.99M;   break;
                case "Normal":  price = people * 249.99M;   break;
            }

            if (people >= 1 && people <= 4)
            {
                budget *= 0.25M;
            }
            else if (people >= 5 && people <= 9)
            {
                budget *= 0.40M;
            }
            else if (people >= 10 && people <= 24)
            {
                budget *= 0.50M;
            }
            else if (people >= 25 && people <= 49)
            {
                budget *= 0.60M;
            }
            else if (people >= 50)
            {
                budget *= 0.75M;
            }

            Console.WriteLine(price <= budget ? $"Yes! You have {budget - price:F2} leva left." : $"Not enough money! You need {price - budget:F2} leva.");
        }
    }
}
