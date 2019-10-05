namespace P01_DiagonalDifference
{
    using System;
    using System.Linq;

    class P01_DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];    
            
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

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primaryDiagonal += matrix[i, i];
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                secondaryDiagonal += matrix[row, (matrix.GetLength(1) - 1) - row];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
