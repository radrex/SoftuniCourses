namespace P05_PrintEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P05_PrintEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < queue.Count; i++)
            {
                int number = queue.Peek();
                if (number % 2 != 0)
                {
                    queue.Dequeue();
                    i--;
                }
                else
                {
                    queue.Dequeue();
                    queue.Enqueue(number);
                }
            }

            Console.WriteLine(String.Join(", ", queue));
        }
    }
}
