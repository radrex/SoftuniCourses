namespace P06_TruckDriver
{
    using System;

    class P06_TruckDriver
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            decimal km = decimal.Parse(Console.ReadLine());
            decimal fuelPrice = 0.0M;

            if (km <= 5000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        fuelPrice = 0.75M;
                        break;

                    case "Summer":
                        fuelPrice = 0.90M;
                        break;

                    case "Winter":
                        fuelPrice = 1.05M;
                        break;
                }
            }
            else if (km > 5000 && km <= 10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        fuelPrice = 0.95M;
                        break;

                    case "Summer":
                        fuelPrice = 1.10M;
                        break;

                    case "Winter":
                        fuelPrice = 1.25M;
                        break;
                }
            }
            else if (km > 10000 && km <= 20000)
            {
                fuelPrice = 1.45M;
            }

            decimal salary = ((km * fuelPrice) * 4.0M) * 0.90M;
            Console.WriteLine($"{salary:F2}");
        }
    }
}
