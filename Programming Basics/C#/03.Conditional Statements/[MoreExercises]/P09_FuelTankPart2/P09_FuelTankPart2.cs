namespace P09_FuelTankPart2
{
    using System;

    class P09_FuelTankPart2
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine().ToLower();
            double liters = double.Parse(Console.ReadLine());
            string card = Console.ReadLine().ToLower();

            double fuelPrice = 0.0;

            if (card == "yes")
            {
                switch (fuelType)
                {
                    case "diesel":
                        fuelPrice = liters * (2.33 - 0.12);
                        break;

                    case "gasoline":
                        fuelPrice = liters * (2.22 - 0.18);
                        break;

                    case "gas":
                        fuelPrice = liters * (0.93 - 0.08);
                        break;

                    default:
                        Console.WriteLine("Invalid fuel!");
                        return;
                }
            }
            else if (card == "no")
            {
                switch (fuelType)
                {
                    case "diesel":
                        fuelPrice = liters * 2.33;
                        break;

                    case "gasoline":
                        fuelPrice = liters * 2.22;
                        break;

                    case "gas":
                        fuelPrice = liters * 0.93;
                        break;

                    default:
                        Console.WriteLine("Invalid fuel!");
                        return;
                }
            }

            if (liters >= 20 && liters <= 25)
            {
                fuelPrice *= 0.92;
            }
            else if (liters > 25)
            {
                fuelPrice *= 0.90;
            }

            Console.WriteLine($"{fuelPrice:F2} lv.");
        }
    }
}
