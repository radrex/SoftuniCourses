namespace P05_Histogram
{
    using System;

    class P05_Histogram
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double count1 = 0;
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;
            double count5 = 0;
            double count = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                ++count;

                if (number >= 800)
                {
                    ++count5;
                }
                else if (number >= 600)
                {
                    ++count4;
                }
                else if (number >= 400)
                {
                    ++count3;
                }
                else if (number >= 200)
                {
                    ++count2;
                }
                else
                {
                    ++count1;
                }
            }

            Console.WriteLine($"{100 * count1 / count:0.00}%");
            Console.WriteLine($"{100 * count2 / count:0.00}%");
            Console.WriteLine($"{100 * count3 / count:0.00}%");
            Console.WriteLine($"{100 * count4 / count:0.00}%");
            Console.WriteLine($"{100 * count5 / count:0.00}%");
        }
    }
}
