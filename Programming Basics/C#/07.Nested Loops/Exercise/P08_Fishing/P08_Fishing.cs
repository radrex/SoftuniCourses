namespace P08_Fishing
{
    using System;

    class P08_Fishing
    {
        static void Main(string[] args)
        {
            int quota = int.Parse(Console.ReadLine());
            string fishName = Console.ReadLine();
            int fishCount = 0;
            double profit = 0.0;

            while (fishName != "Stop")
            {
                double fishKg = double.Parse(Console.ReadLine());
                fishCount++;

                double price = 0.0;
                for (int i = 0; i < fishName.Length; i++)
                {
                    price += fishName[i];
                }
                price /= fishKg;

                if (fishCount % 3 == 0)
                {
                    profit += price;
                }
                else
                {
                    profit -= price;
                }

                if (fishCount == quota)
                {
                    Console.WriteLine($"Lyubo fulfilled the quota!");
                    break;
                }

                fishName = Console.ReadLine();
            }

            if (profit >= 0)
            {
                Console.WriteLine($"Lyubo's profit from {fishCount} fishes is {profit:F2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(profit):F2} leva today.");
            }
        }
    }
}
