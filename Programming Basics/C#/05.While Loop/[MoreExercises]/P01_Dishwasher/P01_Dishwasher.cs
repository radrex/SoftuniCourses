namespace P01_Dishwasher
{
    using System;

    class P01_Dishwasher
    {
        static void Main(string[] args)
        {
            int detergent = int.Parse(Console.ReadLine()) * 750;
            int washedDishes = 0;
            int washedPots = 0;

            int counter = 1;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                int requiredDetergent = 0;
                if (counter % 3 == 0)
                {
                    int pots = int.Parse(command);
                    requiredDetergent = pots * 15;
                    if (detergent >= requiredDetergent)
                    {
                        detergent -= requiredDetergent;
                        washedPots += pots;
                    }
                    else
                    {
                        Console.WriteLine($"Not enough detergent, {requiredDetergent - detergent} ml. more necessary!");
                        return;
                    }
                }
                else
                {
                    int dishes = int.Parse(command);
                    requiredDetergent = dishes * 5;
                    if (detergent >= requiredDetergent)
                    {
                        detergent -= requiredDetergent;
                        washedDishes += dishes;
                    }
                    else
                    {
                        Console.WriteLine($"Not enough detergent, {requiredDetergent - detergent} ml. more necessary!");
                        return;
                    }
                }

                counter++;
            }

            Console.WriteLine("Detergent was enough!");
            Console.WriteLine($"{washedDishes} dishes and {washedPots} pots were washed.");
            Console.WriteLine($"Leftover detergent {detergent} ml.");
        }
    }
}
