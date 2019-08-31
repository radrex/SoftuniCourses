namespace P02_BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                                      .Split(" ")
                                      .Select(int.Parse)
                                      .ToArray();

            int[] numbers = Console.ReadLine()
                                   .Split(" ")
                                   .Select(int.Parse)
                                   .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < parameters[0]; i++)
            {
                if (numbers.Length - 1 < i)
                {
                    break;
                }
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < parameters[1]; i++)
            {
                if (queue.Count == 0)
                {
                    break;
                }
                queue.Dequeue();
            }

            if (queue.Count != 0)
            {
                Console.WriteLine(queue.Contains(parameters[2]) ? $"true" : $"{queue.Min()}");
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
