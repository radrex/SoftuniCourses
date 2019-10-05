namespace P02_SquaresInMatrix
{
    using System;
    using System.Linq;

    class P02_SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                                      .Split(" ")
                                      .Select(int.Parse)
                                      .ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbols = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(char.Parse)
                                        .ToArray();                                     
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = symbols[i];
                }
            }

            int squareMatrices = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                {
                    if (matrix[row, i] == matrix[row, i + 1] &&
                        matrix[row, i] == matrix[row + 1, i] &&
                        matrix[row, i] == matrix[row + 1, i + 1])
                    {
                        squareMatrices++;
                    }
                }
            }

            Console.WriteLine(squareMatrices);
        }
    }
}
