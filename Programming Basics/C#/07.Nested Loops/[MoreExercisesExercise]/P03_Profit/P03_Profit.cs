namespace P03_Profit
{
    using System;

    class P03_Profit
    {
        static void Main(string[] args)
        {
            int oneLv = int.Parse(Console.ReadLine());
            int twoLv = int.Parse(Console.ReadLine());
            int fiveLv = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int x1 = 0; x1 <= oneLv; x1++)
            {
                for (int x2 = 0; x2 <= twoLv; x2++)
                {
                    for (int x3 = 0; x3 <= fiveLv; x3++)
                    {
                        if ((x1 * 1) + (x2 * 2) + (x3 * 5) == sum)
                        {
                            Console.WriteLine($"{x1} * 1 lv. + {x2} * 2 lv. + {x3} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
