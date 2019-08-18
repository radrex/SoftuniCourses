namespace P12_RefactorSpecialNumbers
{
    using System;

    class P12_RefactorSpecialNumbers
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            for (int i = 1; i <= times; i++)
            {
                int sum = 0;
                int num = i;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }

                bool isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{i} -> {isSpecialNum}");
                sum = 0;
            }
        }
    }
}