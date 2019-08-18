namespace P03a_RecursiveFibonacci
{
    using System;

    class P03a_RecursiveFibonacci
    {
        private static long[] fib;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            fib = new long[n + 1];
            Console.WriteLine(Fib(n - 1));
        }

        //------ Recursion with Dynamic Programming (DP), Memoization --------
        public static long Fib(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            if (fib[n] != 0)
            {
                return fib[n];
            }

            fib[n] = Fib(n - 1) + Fib(n - 2);
            return fib[n];
        }
    }
}