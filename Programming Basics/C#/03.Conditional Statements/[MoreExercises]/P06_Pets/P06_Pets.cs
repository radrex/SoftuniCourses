namespace P06_Pets
{
    using System;

    class P06_Pets
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int foodKg = int.Parse(Console.ReadLine());
            double dogConsumption = double.Parse(Console.ReadLine());
            double catConsumption = double.Parse(Console.ReadLine());
            double turtleConsumption = double.Parse(Console.ReadLine()) / 1000.0;

            double foodRequiredKg = (dogConsumption * days) + (catConsumption * days) + (turtleConsumption * days);

            if (foodKg >= foodRequiredKg)
            {
                Console.WriteLine($"{Math.Floor(foodKg - foodRequiredKg)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(foodRequiredKg - foodKg)} more kilos of food are needed.");
            }
        }
    }
}
