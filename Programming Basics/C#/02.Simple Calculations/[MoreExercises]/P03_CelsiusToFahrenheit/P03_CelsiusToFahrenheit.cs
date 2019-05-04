namespace P03_CelsiusToFahrenheit
{
    using System;

    class P03_CelsiusToFahrenheit
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = celsius * (9.0 / 5.0) + 32;

            Console.WriteLine($"{fahrenheit:F2}");
        }
    }
}
