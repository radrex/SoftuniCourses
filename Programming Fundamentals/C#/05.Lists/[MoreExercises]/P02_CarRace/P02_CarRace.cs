namespace P02_CarRace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_CarRace
    {
        static void Main(string[] args)
        {
            List<int> times = Console.ReadLine()
                                     .Split()
                                     .Select(int.Parse)
                                     .ToList();
            double left = 0.0;
            double right = 0.0;

            for (int i = 0; i < times.Count / 2; i++)
            {
                if (times[i] != 0)
                {
                    left += times[i];
                }
                else
                {
                    left *= 0.8;
                }
            }

            for (int i = times.Count - 1; i > times.Count / 2; i--)
            {
                if (times[i] != 0)
                {
                    right += times[i];
                }
                else
                {
                    right *= 0.8;
                }
            }

            Console.WriteLine(left <= right ? $"The winner is left with total time: {left}" : $"The winner is right with total time: {right}");
        }
    }
}