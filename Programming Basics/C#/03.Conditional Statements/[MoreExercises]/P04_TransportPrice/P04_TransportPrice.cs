namespace P04_TransportPrice
{
    using System;

    class P04_TransportPrice
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string time = Console.ReadLine().ToLower();
            double taxiPrice = 0.70;
            double busPrice = double.MaxValue;
            double trainPrice = double.MaxValue;

            switch (time)
            {
                case "day":
                    taxiPrice += km * 0.79;
                    if (km >= 20)
                    {
                        busPrice = km * 0.09;
                    }

                    if (km >= 100)
                    {
                        trainPrice = km * 0.06;
                    }
                    break;

                case "night":
                    taxiPrice += km * 0.90;
                    if (km >= 20)
                    {
                        busPrice = km * 0.09;
                    }

                    if (km >= 100)
                    {
                        trainPrice = km * 0.06;
                    }
                    break;
            }

            if (taxiPrice < busPrice && taxiPrice < trainPrice)
            {
                Console.WriteLine($"{taxiPrice:F2}");
            }
            else if (busPrice < taxiPrice && busPrice < trainPrice)
            {
                Console.WriteLine($"{busPrice:F2}");
            }
            else if (trainPrice < taxiPrice && trainPrice < busPrice)
            {
                Console.WriteLine($"{trainPrice:F2}");
            }
        }
    }
}
