namespace P07_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P07_TruckTour
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] parameters = Console.ReadLine()
                                          .Split()
                                          .Select(int.Parse)
                                          .ToArray();
                queue.Enqueue(parameters);
            }

            int index = 0;
            while (true)
            {
                int fuel = 0;
                foreach (int[] petrolPump in queue)
                {
                    fuel += petrolPump[0] - petrolPump[1];
                    if (fuel < 0)
                    {
                        index++;
                        int[] currentPump = queue.Dequeue();
                        queue.Enqueue(currentPump);
                        break;
                    }
                }

                if (fuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
