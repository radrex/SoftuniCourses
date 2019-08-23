namespace P04_CarNumber
{
    using System;

    class P04_CarNumber
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int d1 = start; d1 <= end; d1++)
            {
                for (int d2 = start; d2 <= end; d2++)
                {
                    for (int d3 = start; d3 <= end; d3++)
                    {
                        for (int d4 = start; d4 <= end; d4++)
                        {
                            if (d1 % 2 == 0)
                            {
                                if (d4 % 2 != 0)
                                {
                                    if ((d1 > d4) && (d2 + d3) % 2 == 0)
                                    {
                                        Console.Write($"{d1}{d2}{d3}{d4} ");
                                    }
                                }
                            }
                            else if (d1 % 2 != 0)
                            {
                                if (d4 % 2 == 0)
                                {
                                    if ((d1 > d4) && (d2 + d3) % 2 == 0)
                                    {
                                        Console.Write($"{d1}{d2}{d3}{d4} ");
                                    }
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
