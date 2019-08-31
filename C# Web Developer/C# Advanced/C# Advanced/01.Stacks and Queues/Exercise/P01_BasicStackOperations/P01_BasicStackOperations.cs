namespace P01_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P01_BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                                      .Split(" ")
                                      .Select(int.Parse)
                                      .ToArray();

            int[] numbers = Console.ReadLine()
                                   .Split(" ")
                                   .Select(int.Parse)
                                   .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < parameters[0]; i++)
            {
                if (numbers.Length - 1 < i)
                {
                    break;
                }
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < parameters[1]; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }
                stack.Pop();
            }

            if (stack.Count != 0)
            {
                Console.WriteLine(stack.Contains(parameters[2]) ? $"true" : $"{stack.Min()}");
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
