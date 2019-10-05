namespace P05_SquareWithMaximumSum
{
    using System;
    using System.Linq;

    class P05_SquareWithMaximumSum
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
                int[] numbers = Console.ReadLine()
                                       .Split(", ")
                                       .Select(int.Parse)
                                       .ToArray();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = numbers[i];
                }
            }

            int maxSum = int.MinValue;
            int[,] bestMatrix = new int[2, 2];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {                
                for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                {
                    int sum = matrix[row, i] + 
                              matrix[row, i + 1] + 
                              matrix[row + 1, i] + 
                              matrix[row + 1, i + 1];

                    if (sum > maxSum)
                    {
                        bestMatrix[0, 0] = matrix[row, i];
                        bestMatrix[0, 1] = matrix[row, i + 1];
                        bestMatrix[1, 0] = matrix[row + 1, i];
                        bestMatrix[1, 1] = matrix[row + 1, i + 1];

                        maxSum = sum;
                    }
                }
            }

            Console.WriteLine($"{bestMatrix[0, 0]} {bestMatrix[0, 1]}");
            Console.WriteLine($"{bestMatrix[1, 0]} {bestMatrix[1, 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
