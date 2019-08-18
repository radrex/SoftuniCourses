namespace P08_FactorialDivision
{
    using System;

    class P08_FactorialDivision
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            long factA = Factorial(a);
            long factB = Factorial(b);
            double division = factA / (double)factB;

            Console.WriteLine($"{division:F2}");
        }

        public static long Factorial(int number)
        {
            //------------- With Recursion -------------
            if (number == 1)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}