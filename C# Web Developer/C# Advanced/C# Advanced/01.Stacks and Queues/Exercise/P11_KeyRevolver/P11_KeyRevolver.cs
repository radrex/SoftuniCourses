namespace P11_KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P11_KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsData = Console.ReadLine()
                                       .Split(" ")
                                       .Select(int.Parse)
                                       .ToArray();
            int[] locksData = Console.ReadLine()
                                     .Split(" ")
                                     .Select(int.Parse)
                                     .ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(locksData);
            Stack<int> bullets = new Stack<int>(bulletsData);

            int shots = 0;
            int bulletsCost = 0;
            while (true)
            {
                if (shots == gunBarrel && bullets.Count != 0)
                {
                    shots = 0;
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - bulletsCost}");
                    return;
                }

                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

                int @lock = locks.Peek();
                int bullet = bullets.Pop();
                shots++;
                bulletsCost += bulletPrice;

                if (bullet <= @lock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
            }
        }
    }
}
