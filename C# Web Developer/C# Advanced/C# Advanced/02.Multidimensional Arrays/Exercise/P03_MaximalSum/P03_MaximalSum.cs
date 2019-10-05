namespace P03_MaximalSum
{
    using System;
    using System.Linq;
    using System.Text;

    class P03_MaximalSum
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowElements = Console.ReadLine()
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = rowElements[i];
                }
            }

            int rowIndex = 0;
            int elementIndex = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int i = 0; i < matrix.GetLength(1) - 2; i++)
                {
                    int matrixSum = matrix[row, i] + matrix[row, i + 1] + matrix[row, i + 2] +
                                    matrix[row + 1, i] + matrix[row + 1, i + 1] + matrix[row + 1, i + 2] +
                                    matrix[row + 2, i] + matrix[row + 2, i + 1] + matrix[row + 2, i + 2];
                    if (matrixSum > maxSum)
                    {
                        rowIndex = row;
                        elementIndex = i;
                        maxSum = matrixSum;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                string line = String.Empty;
                for (int i = elementIndex; i < elementIndex + 3; i++)
                {
                    line += matrix[row, i] + " ";
                }
                sb.AppendLine(line.TrimEnd());
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
