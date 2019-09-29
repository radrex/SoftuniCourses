using System;
using System.Collections.Generic;

namespace PArchive_AutoRepairAndService
{
    class AutoRepairAndService
    {
        static void Main(string[] args)
        {
            string[] cars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(cars);
            Stack<string> stack = new Stack<string>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split('-');
                switch (tokens[0])
                {
                    case "Service":
                        if (queue.Count != 0)
                        {
                            string servedCar = queue.Dequeue();
                            stack.Push(servedCar);
                            Console.WriteLine($"Vehicle {servedCar} got served.");
                        }
                        break;
                    case "CarInfo":
                        Console.WriteLine(queue.Count != 0 && queue.Contains(tokens[1]) ? "Still waiting for service." : "Served.");
                        break;
                    case "History":
                        Console.WriteLine(String.Join(", ", stack));
                        break;
                }
            }

            if (queue.Count != 0)
            {
                Console.WriteLine($"Vehicles for service: {String.Join(", ", queue)}");
            }

            Console.WriteLine($"Served vehicles: {String.Join(", ", stack)}");
        }
    }
}
