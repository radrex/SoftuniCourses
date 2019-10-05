namespace P05_SnakeMoves
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class P05_SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
            char[,] isle = new char[dimensions[0], dimensions[1]];
            string str = Console.ReadLine();

            Queue<char> snake = new Queue<char>(str);

            for (int row = 0; row < isle.GetLength(0); row++)
            {
                if (row % 2 != 0)
                {
                    for (int i = isle.GetLength(1) - 1; i >= 0; i--)
                    {
                        char symbol = snake.Dequeue();
                        isle[row, i] = symbol;
                        snake.Enqueue(symbol);
                    }
                }
                else
                {
                    for (int i = 0; i < isle.GetLength(1); i++)
                    {
                        char symbol = snake.Dequeue();
                        isle[row, i] = symbol;
                        snake.Enqueue(symbol);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < isle.GetLength(0); row++)
            {
                string line = String.Empty;
                for (int i = 0; i < isle.GetLength(1); i++)
                {
                    line += isle[row, i];
                }
                sb.AppendLine(line);
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
