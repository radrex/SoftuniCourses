namespace P04_FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P04_FastFood
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                                  .Split(" ")
                                  .Select(int.Parse)
                                  .ToArray();
            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());

            for (int i = 0; i < orders.Length; i++)
            {            
                if (queue.Count != 0)
                {
                    if (queue.Peek() > food)
                    {
                        break;
                    }

                    food -= queue.Dequeue();
                }
            }

            Console.WriteLine(queue.Count == 0 ? "Orders complete" : $"Orders left: {String.Join(" ", queue)}");
        }
    }
}
