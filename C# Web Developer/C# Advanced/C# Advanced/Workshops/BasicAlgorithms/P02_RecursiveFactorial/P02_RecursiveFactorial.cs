namespace P02_RecursiveFactorial
{
    using System;

    class P02_RecursiveFactorial
    {
        static void Main(string[] args)
        {
            int result = Factorial(5);
            Console.WriteLine(result);
        }

        private static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
