namespace P08_TownInfo
{
    using System;

    class P08_TownInfo
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            uint population = uint.Parse(Console.ReadLine());
            ushort area = ushort.Parse(Console.ReadLine());

            Console.WriteLine($"Town {town} has population of {population} and area {area} square km.");
        }
    }
}