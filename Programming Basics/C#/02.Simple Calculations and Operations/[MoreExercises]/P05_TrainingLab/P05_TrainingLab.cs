namespace P05_TrainingLab
{
    using System;

    class P05_TrainingLab
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            int tables = (int)((h * 100) - 100) / 70;
            int rows = (int)(w * 100) / 120;

            int places = rows * tables - 3;
            Console.WriteLine(places);
        }
    }
}
