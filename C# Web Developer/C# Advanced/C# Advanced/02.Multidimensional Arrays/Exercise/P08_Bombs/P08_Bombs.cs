namespace P08_Bombs
{
    using System;
    using System.Linq;
    using System.Text;

    class P08_Bombs
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

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

            bool[,] bombsLocations = new bool[size, size];
            string[] bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int n = 0; n < bombs.Length; n++)
            {
                int[] indexes = bombs[n].Split(',').Select(int.Parse).ToArray();
                int row = indexes[0];
                int i = indexes[1];

                bombsLocations[row, i] = true;

                if (bombsLocations[row, i] == true && matrix[row, i] > 0) // IF BOMB ON THE CURRENT CELL && BOMB LIFE > 0 (STILL NOT DETONATED)
                {
                    //------------------------------------- 1 ROW UP --------------------------------------------------------------------------
                    if (row - 1 >= 0)   // CHECK IF TOP ROW IS IN MATRIX BOUNDARIES
                    {
                        if (matrix[row - 1, i] > 0) // IF TOP CELL (1 UP) LIFE > 0 --> DAMAGE THE CELL
                        {
                            matrix[row - 1, i] -= matrix[row, i];
                        }

                        if (i - 1 >= 0)   // CHECK IF LEFT DIAGONAL (1 UP, 1 LEFT) IS IN MATRIX BOUNDARIES
                        {
                            if (matrix[row - 1, i - 1] > 0)     // IF CELL LIFE > 0 --> DAMAGE THE CELL
                            {
                                matrix[row - 1, i - 1] -= matrix[row, i];
                            }
                        }

                        if (i + 1 < matrix.GetLength(1))  // CHECK IF RIGHT DIAGONAL (1 UP, 1 RIGHT) IS IN MATRIX BOUNDARIES
                        {
                            if (matrix[row - 1, i + 1] > 0)   // IF CELL LIFE > 0 --> DAMAGE THE CELL
                            {
                                matrix[row - 1, i + 1] -= matrix[row, i];
                            }
                        }
                    }
                    //------------------------------------- SAME ROW --------------------------------------------------------------------------
                    if (i - 1 >= 0)   // CHECK IF CELL ON THE LEFT (SAME ROW) IS IN MATRIX BOUNDARIES
                    {
                        if (matrix[row, i - 1] > 0)   // IF CELL LIFE > 0 --> DAMAGE THE CELL
                        {
                            matrix[row, i - 1] -= matrix[row, i];
                        }
                    }

                    if (i + 1 < matrix.GetLength(1))  // CHECK IF CELL ON THE RIGHT (SAME ROW) IS IN MATRIX BOUNDARIES
                    {
                        if (matrix[row, i + 1] > 0) // IF CELL LIFE > 0 --> DAMAGE THE CELL
                        {
                            matrix[row, i + 1] -= matrix[row, i];
                        }
                    }
                    //------------------------------------ 1 ROW DOWN --------------------------------------------------------------------------
                    if (row + 1 < matrix.GetLength(0)) // CHECK IF BOTTOM ROW IS IN MATRIX BOUNDARIES
                    {
                        if (matrix[row + 1, i] > 0)   // IF BOTTOM CELL (1 DOWN) LIFE > 0 --> DAMAGE THE CELL
                        {
                            matrix[row + 1, i] -= matrix[row, i];
                        }

                        if (i - 1 >= 0)   // CHECK IF LEFT DIAGONAL (1 DOWN, 1 LEFT) IS IN MATRIX BOUNDARIES
                        {
                            if (matrix[row + 1, i - 1] > 0) // IF CELL LIFE > 0 --> DAMAGE THE CELL
                            {
                                matrix[row + 1, i - 1] -= matrix[row, i];
                            }
                        }

                        if (i + 1 < matrix.GetLength(1))  // CHECK IF RIGHT DIAGONAL (1 DOWN, 1 RIGHT) IS IN MATRIX BOUNDARIES
                        {
                            if (matrix[row + 1, i + 1] > 0) // IF CELL LIFE > 0 --> DAMAGE THE CELL
                            {
                                matrix[row + 1, i + 1] -= matrix[row, i];
                            }
                        }
                    }

                    matrix[row, i] = 0; // BOMB DETONATED, SET VALUE TO 0
                }
            }

            StringBuilder sb = new StringBuilder();
            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = String.Empty;
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[row, i] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, i];
                    }

                    line += matrix[row, i] + " ";
                }

                sb.AppendLine(line.TrimEnd());
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
