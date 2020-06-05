namespace P03_GamingStore
{
    using System;

    class P03_GamingStore
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string game = Console.ReadLine();
            double expenses = 0.0;

            while (game != "Game Time")
            {
                double gamePrice = 0.0;
                switch (game)
                {
                    case "OutFall 4":
                        gamePrice = 39.99;
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        game = Console.ReadLine();
                        continue;
                }

                if (balance >= gamePrice)
                {
                    Console.WriteLine($"Bought {game}");
                    expenses += gamePrice;
                    balance -= gamePrice;
                }
                else if (balance < gamePrice)
                {
                    Console.WriteLine("Too Expensive");
                }

                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                game = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${expenses:F2}. Remaining: ${balance:F2}");
        }
    }
}