namespace P01_PipesInPool
{
    using System;

    class P01_PipesInPool
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double water = (p1 + p2) * hours;

            if (volume < water)
            {
                Console.WriteLine($"For {hours:F2} hours the pool overflows with {water - volume:F2} liters.");
            }
            else
            {
                double waterPercentage = (water / volume) * 100;
                double pipe1Percentage = (p1 * hours) / water * 100;
                double pipe2Percentage = (p2 * hours) / water * 100;
                Console.WriteLine($"The pool is {waterPercentage:F2}% full. Pipe 1: {pipe1Percentage:F2}%. Pipe 2: {pipe2Percentage:F2}%.");
            }
        }
    }
}
