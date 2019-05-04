namespace P06_Journey
{
    using System;

    class P06_Journey
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            double expenses = 0.0;

            switch (season)
            {
                case "summer":
                    if (budget <= 100)
                    {
                        expenses = budget * 0.30;
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"Camp - {expenses:F2}");
                    }
                    else if (budget <= 1000)
                    {
                        expenses = budget * 0.40;
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"Camp - {expenses:F2}");
                    }
                    else
                    {
                        expenses = budget * 0.90;
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"Hotel - {expenses:F2}");
                    }
                    break;

                case "winter":
                    if (budget <= 100)
                    {
                        expenses = budget * 0.70;
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"Hotel - {expenses:F2}");
                    }
                    else if (budget <= 1000)
                    {
                        expenses = budget * 0.80;
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"Hotel - {expenses:F2}");
                    }
                    else
                    {
                        expenses = budget * 0.90;
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"Hotel - {expenses:F2}");
                    }
                    break;
            }
        }
    }
}
