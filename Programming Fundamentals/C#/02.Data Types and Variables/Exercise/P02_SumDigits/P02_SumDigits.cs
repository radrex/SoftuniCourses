namespace P02_SumDigits
{
    using System;

    class P02_SumDigits
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int sum = 0;

            foreach (int digit in num)
            {
                sum += digit - 48;
            }

            Console.WriteLine(sum);
        }
    }
}