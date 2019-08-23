namespace P05_GameOfIntervals
{
    using System;

    class P05_GameOfIntervals
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double points = 0.0;

            int invalidNums = 0;
            int from_0_to_9 = 0;
            int from_10_to_19 = 0;
            int from_20_to_29 = 0;
            int from_30_to_39 = 0;
            int from_40_to_50 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 0 || num > 50)
                {
                    invalidNums++;
                    points /= 2;
                    continue;
                }

                if (num >= 0 && num <= 9)
                {
                    from_0_to_9++;
                    points += num * 0.20;
                }
                else if (num >= 10 && num <= 19)
                {
                    from_10_to_19++;
                    points += num * 0.30;
                }
                else if (num >= 20 && num <= 29)
                {
                    from_20_to_29++;
                    points += num * 0.40;
                }
                else if (num >= 30 && num <= 39)
                {
                    from_30_to_39++;
                    points += 50;
                }
                else if (num >= 40 && num <= 50)
                {
                    from_40_to_50++;
                    points += 100;
                }
            }

            Console.WriteLine($"{points:F2}");
            Console.WriteLine($"From 0 to 9: {((double)from_0_to_9 / n) * 100:F2}%");
            Console.WriteLine($"From 10 to 19: {((double)from_10_to_19 / n) * 100:F2}%");
            Console.WriteLine($"From 20 to 29: {((double)from_20_to_29 / n) * 100:F2}%");
            Console.WriteLine($"From 30 to 39: {((double)from_30_to_39 / n) * 100:F2}%");
            Console.WriteLine($"From 40 to 50: {((double)from_40_to_50 / n) * 100:F2}%");
            Console.WriteLine($"Invalid numbers: {((double)invalidNums / n) * 100:F2}%");
        }
    }
}
