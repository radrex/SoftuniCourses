namespace P04_BitDestroyer
{
    using System;

    class P04_BitDestroyer
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int mask = 1 << p;
            mask = ~mask;

            Console.WriteLine(n & mask);
        }
    }
}
