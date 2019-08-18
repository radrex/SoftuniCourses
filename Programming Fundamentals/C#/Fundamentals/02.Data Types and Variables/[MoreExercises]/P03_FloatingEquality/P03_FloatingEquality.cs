namespace P03_FloatingEquality
{
    using System;

    class P03_FloatingEquality
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double epsilon = 0.000001;

            bool areEqual = Math.Abs(num1 - num2) < epsilon ? true : false;

            Console.WriteLine(areEqual);
        }
    }
}