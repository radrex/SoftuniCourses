namespace P01_ConvertMetersToKilometers
{
    using System;

    class P01_ConvertMetersToKilometers
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            double kilometers = meters / 1000.0;

            Console.WriteLine($"{kilometers:F2}");
        }
    }
}