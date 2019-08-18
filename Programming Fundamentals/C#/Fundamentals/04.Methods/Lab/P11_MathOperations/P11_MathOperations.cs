namespace P11_MathOperations
{
    using System;

    class P11_MathOperations
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            double result = Calculate(a, @operator, b);
            Console.WriteLine(result);
        }

        public static double Calculate(int a, char @operator, int b)
        {
            double result = 0.0;
            switch (@operator)
            {
                case '+': result = a + b; break;
                case '-': result = a - b; break;
                case '*': result = a * b; break;
                case '/': result = a / b; break;
            }
            return result;
        }
    }
}