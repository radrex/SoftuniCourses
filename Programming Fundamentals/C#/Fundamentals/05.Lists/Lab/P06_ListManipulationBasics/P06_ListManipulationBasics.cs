namespace P06_ListManipulationBasics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P06_ListManipulationBasics
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int number = int.Parse(tokens[1]);
                        numbers.Add(number);
                        break;
                    case "Remove":
                        number = int.Parse(tokens[1]);
                        numbers.Remove(number);
                        break;
                    case "RemoveAt":
                        number = int.Parse(tokens[1]);
                        numbers.RemoveAt(number);
                        break;
                    case "Insert":
                        number = int.Parse(tokens[1]);
                        int index = int.Parse(tokens[2]);
                        numbers.Insert(index, number);
                        break;
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}