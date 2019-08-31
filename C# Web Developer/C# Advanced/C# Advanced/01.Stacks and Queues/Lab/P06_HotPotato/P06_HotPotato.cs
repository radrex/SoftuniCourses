namespace P06_HotPotato
{
    using System;
    using System.Collections.Generic;

    class P06_HotPotato
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            Queue<string> queue = new Queue<string>(children);
            int n = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    string child = queue.Dequeue();
                    queue.Enqueue(child);
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
