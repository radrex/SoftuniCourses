namespace P02_StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_StackSum
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                                .Split(" ")
                                .Select(int.Parse)
                                .ToArray();
            Stack<int> stack = new Stack<int>(nums);

            while (true)
            {
                string command = Console.ReadLine()?.ToLower();
                if (command == "end")
                {
                    break;
                }

                string[] commands = command.Split(" ");
                switch(commands[0])
                {
                    case "add":
                        int n1 = int.Parse(commands[1]);
                        int n2 = int.Parse(commands[2]);
                        stack.Push(n1);
                        stack.Push(n2);
                        break;

                    case "remove":
                        int count = int.Parse(commands[1]);
                        if (stack.Count < count)
                        {
                            continue;
                        }

                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }

                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
