namespace P07_ListManipulationAdvanced
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P07_ListManipulationAdvanced
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();
            bool areChangesMade = false;

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "Add":
                        int number = int.Parse(tokens[1]);
                        numbers.Add(number);
                        areChangesMade = true;
                        break;

                    case "Remove":
                        number = int.Parse(tokens[1]);
                        numbers.Remove(number);
                        areChangesMade = true;
                        break;

                    case "RemoveAt":
                        number = int.Parse(tokens[1]);
                        numbers.RemoveAt(number);
                        areChangesMade = true;
                        break;

                    case "Insert":
                        number = int.Parse(tokens[1]);
                        int index = int.Parse(tokens[2]);
                        numbers.Insert(index, number);
                        areChangesMade = true;
                        break;

                    case "Contains":
                        number = int.Parse(tokens[1]);
                        Console.WriteLine(numbers.Contains(number) ? "Yes" : "No such number");
                        break;

                    case "PrintEven":
                        string message = string.Empty;
                        foreach (int num in numbers.Where(n => n % 2 == 0))
                        {
                            message += $"{num} ";
                        }
                        Console.WriteLine(message.TrimEnd());
                        break;

                    case "PrintOdd":
                        message = string.Empty;
                        foreach (int num in numbers.Where(n => n % 2 != 0))
                        {
                            message += $"{num} ";
                        }
                        Console.WriteLine(message.TrimEnd());
                        break;

                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;

                    case "Filter":
                        string condition = tokens[1];
                        number = int.Parse(tokens[2]);
                        message = string.Empty;
                        switch (condition)
                        {
                            case "<":
                                foreach (int num in numbers.Where(n => n < number))
                                {
                                    message += $"{num} ";
                                }
                                break;

                            case ">":
                                foreach (int num in numbers.Where(n => n > number))
                                {
                                    message += $"{num} ";
                                }
                                break;

                            case ">=":
                                foreach (int num in numbers.Where(n => n >= number))
                                {
                                    message += $"{num} ";
                                }
                                break;

                            case "<=":
                                foreach (int num in numbers.Where(n => n <= number))
                                {
                                    message += $"{num} ";
                                }
                                break;
                        }
                        Console.WriteLine(message.TrimEnd());
                        break;
                }

                input = Console.ReadLine();
            }

            if (areChangesMade)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }
    }
}