namespace P02_ReportSystem
{
    using System;

    class P02_ReportSystem
    {
        static void Main(string[] args)
        {
            int goal = int.Parse(Console.ReadLine());
            int funds = 0;

            int withCash = 0;
            int cashCounter = 0;

            int withCard = 0;
            int cardCounter = 0;

            int counter = 1;
            while (true)
            {
                if (funds >= goal)
                {
                    Console.WriteLine($"Average CS: {(double)withCash / cashCounter:F2}");
                    Console.WriteLine($"Average CC: {(double)withCard / cardCounter:F2}");
                    return;
                }

                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine("Failed to collect required money for charity.");
                    break;
                }

                int price = int.Parse(command);
                if (counter % 2 == 0)
                {
                    if (price < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        withCard += price;
                        funds += price;
                        cardCounter++;
                        Console.WriteLine("Product sold!");
                    }
                }
                else
                {
                    if (price > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        withCash += price;
                        funds += price;
                        cashCounter++;
                        Console.WriteLine("Product sold!");
                    }
                }

                counter++;
            }
        }
    }
}
