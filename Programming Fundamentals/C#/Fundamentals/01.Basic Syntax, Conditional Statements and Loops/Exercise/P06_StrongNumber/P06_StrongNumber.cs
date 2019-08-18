namespace P06_StrongNumber
{
    using System;

    class P06_StrongNumber
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int strongNum = 0;

            foreach (char digit in num.ToString())
            {
                int parsedDigit = digit - '0'; // ASCII Hack... hehehe
                int factorial = 1;

                for (int i = 1; i <= parsedDigit; i++)
                {
                    factorial *= i;
                }

                strongNum += factorial;
            }

            Console.WriteLine(num == strongNum ? "yes" : "no");
        }
    }
}