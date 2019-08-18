namespace P01_SignOfIntegerNumbers
{
    using System;

    class P01_SignOfIntegerNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintSign(number);
        }

        public static void PrintSign(int number)
        {
            if (number == 0)
            {
                Console.WriteLine("The number 0 is zero.");
                return;
            }

            Console.WriteLine(number > 0 ? $"The number {number} is positive." : $"The number {number} is negative.");
        }
    }
}