namespace P02_SumMatrixColumns
{
    using System;
    using System.Linq;

    class P02_SumMatrixColumns
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                                      .Split(", ")
                                      .Select(int.Parse)
                                      .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowElements = Console.ReadLine()
                                           .Split(" ")
                                           .Select(int.Parse)
                                           .ToArray();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = rowElements[i];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i , col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
