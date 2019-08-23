namespace P09_WeatherForecastPart2
{
    using System;

    class P09_WeatherForecastPart2
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());

            if (celsius >= 26.0 && celsius <= 35.0)
            {
                Console.WriteLine("Hot");
            }
            else if (celsius >= 20.1 && celsius <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (celsius >= 15.0 && celsius <= 20.0)
            {
                Console.WriteLine("Mild");
            }
            else if (celsius >= 12.0 && celsius <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (celsius >= 5.0 && celsius <= 11.9)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
