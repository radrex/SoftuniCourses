namespace P03_PrimaryDiagonal
{
    using System;
    using System.Linq;

    class P03_PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                                       .Split(" ")
                                       .Select(int.Parse)
                                       .ToArray();

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = numbers[i];
                }
            }

            int diagonalSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                diagonalSum += matrix[i, i];
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
