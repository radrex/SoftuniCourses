namespace P07_TrafficJam
{
    using System;
    using System.Collections.Generic;

    class P07_TrafficJam
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            int cars = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    Console.WriteLine($"{cars} cars passed the crossroads.");
                    break;
                }

                string[] tokens = command.Split(" ");
                switch (tokens[0])
                {
                    case "green":
                        int count = queue.Count > n ? n : queue.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            cars++;
                        }
                        break;

                    default:
                        queue.Enqueue(command);
                        break;
                }
            }
        }
    }
}
