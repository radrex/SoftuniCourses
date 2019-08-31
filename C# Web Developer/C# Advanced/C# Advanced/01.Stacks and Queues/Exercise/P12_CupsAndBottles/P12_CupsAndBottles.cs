namespace P12_CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P12_CupsAndBottles
    {
        static void Main(string[] args)
        {
            int[] cupsData = Console.ReadLine()
                                    .Split(" ")
                                    .Select(int.Parse)
                                    .ToArray();
            int[] bottlesData = Console.ReadLine()
                                       .Split(" ")
                                       .Select(int.Parse)
                                       .ToArray();

            Queue<int> cups = new Queue<int>(cupsData);
            Stack<int> bottles = new Stack<int>(bottlesData);

            int wastedWater = 0;
            while (true)
            {
                if (cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }

                if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {String.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }

                int cup = cups.Peek();
                int bottle = bottles.Pop();

                while (cup > bottle)
                {
                    cup -= bottle;
                    if (bottles.Count == 0)
                    {
                        Console.WriteLine($"Cups: {String.Join(" ", cups)}");
                        Console.WriteLine($"Wasted litters of water: {wastedWater}");
                        return;
                    }
                    bottle = bottles.Pop();
                }

                cup -= bottle;
                if (cup <= 0)
                {
                    cups.Dequeue();

                    if (cup < 0)
                    {
                        wastedWater += Math.Abs(cup);
                    }
                }
            }
        }
    }
}