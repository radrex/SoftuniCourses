namespace P03_PthBit
{
    using System;

    class P03_PthBit
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int shifter = int.Parse(Console.ReadLine());

            int shifted = n >> shifter;

            Console.WriteLine(shifted & 1);
        }
    }
}
