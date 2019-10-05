namespace P06_JaggedArrayManipulator
{
    using System;
    using System.Linq;

    class P06_JaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] elements = Console.ReadLine()
                                           .Split()
                                           .Select(double.Parse)
                                           .ToArray();
                jaggedArr[row] = elements;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int i = 0; i < jaggedArr[row].Length; i++)
                    {
                        jaggedArr[row][i] *= 2;
                        jaggedArr[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jaggedArr[row].Length; i++)
                    {
                        jaggedArr[row][i] /= 2;
                    }

                    for (int i = 0; i < jaggedArr[row + 1].Length; i++)
                    {
                        jaggedArr[row + 1][i] /= 2;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    for (int i = 0; i < jaggedArr.GetLength(0); i++)
                    {
                        Console.WriteLine(String.Join(" ", jaggedArr[i]));
                    }

                    return;
                }

                string[] tokens = command.Split();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row >= 0 && row < jaggedArr.GetLength(0) && col >= 0 && col < jaggedArr[row].Length)
                {
                    switch (tokens[0])
                    {
                        case "Add":
                            jaggedArr[row][col] += value;
                            break;

                        case "Subtract":
                            jaggedArr[row][col] -= value;
                            break;
                    }
                }
            }
        }
    }
}
