namespace P04_MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    class P04_MatchingBrackets
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int index = stack.Pop();
                    Console.WriteLine(expression.Substring(index, i - index + 1));
                }
            }
        }
    }
}
