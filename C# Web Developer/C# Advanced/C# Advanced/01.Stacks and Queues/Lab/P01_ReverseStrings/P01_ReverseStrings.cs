namespace P01_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    class P01_ReverseStrings
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (char symbol in text)
            {
                stack.Push(symbol);
            }

            Console.WriteLine(String.Join("", stack.ToArray()));
        }
    }
}
