namespace P01_Train
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P01_Train
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToList();

            int wagonCapacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    wagons.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagonCapacity - wagons[i] >= int.Parse(command[0]))
                        {
                            wagons[i] += int.Parse(command[0]);
                            break;
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}