namespace P06_TriBitSwitch
{
    using System;

    class P06_TriBitSwitch
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            long mask = 7L << p;
            long result = n ^ mask;
            Console.WriteLine(result);
        }
    }
}
