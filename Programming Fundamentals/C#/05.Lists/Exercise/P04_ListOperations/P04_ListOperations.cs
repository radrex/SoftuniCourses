namespace P04_ListOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P04_ListOperations
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Add":
                        int number = int.Parse(command[1]);
                        numbers.Add(number);
                        break;

                    case "Insert":
                        number = int.Parse(command[1]);
                        int index = int.Parse(command[2]);
                        if (index < 0 || index >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.Insert(index, number);
                        }
                        break;

                    case "Remove":
                        index = int.Parse(command[1]);
                        if (index < 0 || index >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.RemoveAt(index);
                        }
                        break;

                    case "Shift":
                        switch (command[1])
                        {
                            case "left":
                                int count = int.Parse(command[2]);
                                for (int i = 0; i < count; i++)
                                {
                                    numbers.Add(numbers.First());
                                    numbers.RemoveAt(0);
                                }
                                break;

                            case "right":
                                count = int.Parse(command[2]);
                                for (int i = 0; i < count; i++)
                                {
                                    numbers.Insert(0, numbers.Last());
                                    numbers.RemoveAt(numbers.Count - 1);
                                }
                                break;
                        }
                        break;
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}