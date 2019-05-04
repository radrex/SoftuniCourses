namespace P05_DanceHall
{
    using System;

    class P05_DanceHall
    {
        static void Main(string[] args)
        {
            double hallLength = double.Parse(Console.ReadLine());
            double hallWidth = double.Parse(Console.ReadLine());
            double wardrobeSide = double.Parse(Console.ReadLine());

            double hallArea = (hallLength * 100) * (hallWidth * 100);
            double wardrobeArea = (wardrobeSide * 100) * (wardrobeSide * 100);
            double benchArea = hallArea / 10;

            double freeSpace = hallArea - wardrobeArea - benchArea;
            double dancersCount = (hallArea - wardrobeArea - benchArea) / (40 + 7000);

            Console.WriteLine($"{Math.Floor(dancersCount)}");
        }
    }
}
