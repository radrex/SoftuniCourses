namespace P02_FirstBit
{
    using System;

    class P02_FirstBit
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int shifted = n >> 1;

            Console.WriteLine(shifted & 1);
        }
    }
}
