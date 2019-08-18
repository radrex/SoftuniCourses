namespace P10_MultiplyEvensByOdds
{
    using System;

    class P10_MultiplyEvensByOdds
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int result = GetMultipleOfEvenAndOdds(number);
            Console.WriteLine(result);
        }

        public static int GetMultipleOfEvenAndOdds(int number)
        {
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        public static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;
            foreach (char digit in Math.Abs(number).ToString())
            {
                int num = digit - '0';
                if (num % 2 == 0)
                {
                    sum += num;
                }
            }

            return sum;
        }

        public static int GetSumOfOddDigits(int number)
        {
            int sum = 0;
            foreach (char digit in Math.Abs(number).ToString())
            {
                int num = digit - '0';
                if (num % 2 != 0)
                {
                    sum += num;
                }
            }

            return sum;
        }
    }
}