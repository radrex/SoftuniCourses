namespace P04_MatrixShuffling
{
    using System;
    using System.Linq;
    using System.Text;

    class P04_MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = rowElements[i];                    
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Length > 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (tokens[0])
                {
                    case "swap":
                        int row1 = int.Parse(tokens[1]);
                        int i1 = int.Parse(tokens[2]);
                        int row2 = int.Parse(tokens[3]);
                        int i2 = int.Parse(tokens[4]);

                        if (row1 < 0 || row1 > matrix.GetLength(0) - 1 || i1 < 0 || i1 > matrix.GetLength(1) - 1 ||
                            row2 < 0 || row2 > matrix.GetLength(0) - 1 || i2 < 0 || i2 > matrix.GetLength(1) - 1)
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }

                        string swap = matrix[row1, i1];
                        matrix[row1, i1] = matrix[row2, i2];
                        matrix[row2, i2] = swap;

                        StringBuilder sb = new StringBuilder();
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            string line = String.Empty;
                            for (int i = 0; i < matrix.GetLength(1); i++)
                            {
                                line += matrix[row, i] + " ";
                            }
                            sb.AppendLine(line.TrimEnd());
                        }

                        Console.WriteLine(sb.ToString().TrimEnd());
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }           
            }
        }
    }
}
