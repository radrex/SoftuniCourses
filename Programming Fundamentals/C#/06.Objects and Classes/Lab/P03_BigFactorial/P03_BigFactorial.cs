namespace P03_BigFactorial
{
    using System;
    using System.Numerics;

    class P03_BigFactorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;

            for (int i = 2; i <= n; i++)
            {
                factorial = factorial * i;
            }

            Console.WriteLine(factorial);
        }
    }
}