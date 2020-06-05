namespace P05_MultiplicationSign
{
    using System;

    class P05_MultiplicationSign
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            MultiplicationSign(num1, num2, num3);
        }

        public static void MultiplicationSign(int num1, int num2, int num3)
        {
            if ((num1 == 0 || num2 == 0 || num3 == 0))
            {
                Console.WriteLine("zero");
                return;
            }
            Console.WriteLine((num1 > 0 && num2 > 0 && num3 > 0) ||
                              (num1 < 0 && num2 < 0 && num3 > 0) ||
                              (num1 < 0 && num2 > 0 && num3 < 0) ||
                              (num1 > 0 && num2 < 0 && num3 < 0) ? "positive" : "negative");

        }
    }
}