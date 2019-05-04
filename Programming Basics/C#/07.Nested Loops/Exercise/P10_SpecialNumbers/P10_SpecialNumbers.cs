namespace P10_SpecialNumbers
{
    using System;

    class P10_SpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 0;

            for (int i = 1111; i <= 9999; i++)
            {
                int d4 = i % 10;
                num = i / 10;

                int d3 = num % 10;
                num = num / 10;

                int d2 = num % 10;
                num = num / 10;

                int d1 = num % 10;

                if (d1 != 0 && d2 != 0 && d3 != 0 && d4 != 0)
                {
                    if (n % d1 == 0 && 
                        n % d2 == 0 && 
                        n % d3 == 0 && 
                        n % d4 == 0)
                    {
                        Console.Write($"{d1}{d2}{d3}{d4} ");
                    }
                }
            }
        }
    }
}
