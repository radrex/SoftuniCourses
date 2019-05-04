namespace P07_OperationsBetweenNumbers
{
    using System;

    class P07_OperationsBetweenNumbers
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char operand = char.Parse(Console.ReadLine());

            int result = 0;
            string evenOrOdd = string.Empty;

            double divideResult = 0.0;

            switch (operand)
            {
                case '+':
                    result = n1 + n2;
                    evenOrOdd = (result % 2 == 0) ? "even" : "odd";
                    Console.WriteLine($"{n1} + {n2} = {result} - {evenOrOdd}");
                    break;

                case '-':
                    result = n1 - n2;
                    evenOrOdd = (result % 2 == 0) ? "even" : "odd";
                    Console.WriteLine($"{n1} - {n2} = {result} - {evenOrOdd}");
                    break;

                case '*':
                    result = n1 * n2;
                    evenOrOdd = (result % 2 == 0) ? "even" : "odd";
                    Console.WriteLine($"{n1} * {n2} = {result} - {evenOrOdd}");
                    break;

                case '/':
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        return;
                    }
                    divideResult = (double)n1 / n2;
                    Console.WriteLine($"{n1} / {n2} = {divideResult:F2}");
                    break;

                case '%':
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        return;
                    }
                    divideResult = (double)n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {divideResult}");
                    break;
            }
        }
    }
}
