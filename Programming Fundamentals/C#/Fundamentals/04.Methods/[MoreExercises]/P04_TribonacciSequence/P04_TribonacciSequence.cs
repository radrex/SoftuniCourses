namespace P04_TribonacciSequence
{
    using System;

    class P04_TribonacciSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Fib(n);
        }
        //------ Recursion with Dynamic Programming (DP), Memoization --------
        public static void Fib(int n)
        {
            long[] fib = new long[n + 1];
            string sequence = string.Empty;

            if (n <= 0)
            {
                sequence += "0";
            }
            else if (n == 1)
            {
                sequence += "1";
            }
            else if (n == 2)
            {
                sequence += "1 1";
            }
            else if (n == 3)
            {
                sequence += "1 1 2 ";
            }
            else
            {
                fib[0] = 0;
                fib[1] = 1;
                fib[2] = 1;
                sequence += $"{fib[1]} {fib[2]} ";

                for (int i = 3; i <= n; i++)
                {
                    fib[i] = fib[i - 1] + fib[i - 2] + fib[i - 3];
                    sequence += $"{fib[i]} ";
                }
            }

            Console.WriteLine(sequence.TrimEnd());
        }
    }
}