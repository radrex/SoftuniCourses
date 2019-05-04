namespace P03_LuckyNumbers
{
    using System;

    class P03_LuckyNumbers
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int d1 = 1; d1 <= 9; d1++)
            {
                for (int d2 = 1; d2 <= 9; d2++)
                {
                    for (int d3 = 1; d3 <= 9; d3++)
                    {
                        for (int d4 = 1; d4 <= 9; d4++)
                        {
                            if (d1 + d2 == d3 + d4)
                            {
                                if (num % (d1 + d2) == 0)
                                {
                                    Console.Write($"{d1}{d2}{d3}{d4} ");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
