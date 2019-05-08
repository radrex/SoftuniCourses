namespace P08_FuelTank
{
    using System;

    class P08_FuelTank
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuel = double.Parse(Console.ReadLine());

            switch (fuelType)
            {
                case "Diesel":
                    fuelType = "diesel";
                    break;

                case "Gasoline":
                    fuelType = "gasoline";
                    break;

                case "Gas":
                    fuelType = "gas";
                    break;

                default:
                    Console.WriteLine("Invalid fuel!");
                    return;
            }

            if (fuel >= 25)
            {
                Console.WriteLine($"You have enough {fuelType}.");
            }
            else
            {
                Console.WriteLine($"Fill your tank with {fuelType}!");
            }
        }
    }
}
