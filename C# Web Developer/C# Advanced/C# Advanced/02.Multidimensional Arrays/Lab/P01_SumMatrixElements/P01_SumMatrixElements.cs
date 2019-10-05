namespace P01_SumMatrixElements
{
    using System;
    using System.Linq;

    class P01_SumMatrixElements
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
                                           .Split(", ")
                                           .Select(int.Parse)
                                           .ToArray();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = rowElements[i];
                }
            }

            int sum = 0;
            foreach (int element in matrix)
            {
                sum += element;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
