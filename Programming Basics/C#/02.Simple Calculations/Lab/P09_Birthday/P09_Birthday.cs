namespace P09_Birthday
{
    using System;

    class P09_Birthday
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            percent = percent * 0.01;

            double aquariumVolume = Math.Round((width * length * height * 0.001), 3);
            double liters = aquariumVolume * (1 - percent);

            Console.WriteLine($"{liters:F3}");
        }
    }
}
