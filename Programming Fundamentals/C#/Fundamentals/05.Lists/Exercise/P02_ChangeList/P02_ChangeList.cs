namespace P02_ChangeList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Delete":
                        int element = int.Parse(command[1]);
                        numbers.RemoveAll(n => n == element);
                        break;

                    case "Insert":
                        element = int.Parse(command[1]);
                        int index = int.Parse(command[2]);
                        numbers.Insert(index, element);
                        break;
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
