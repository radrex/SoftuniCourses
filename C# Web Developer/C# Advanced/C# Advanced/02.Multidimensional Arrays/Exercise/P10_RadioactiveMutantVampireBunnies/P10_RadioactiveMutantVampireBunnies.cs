namespace P10_RadioactiveMutantVampireBunnies
{
    using System;
    using System.Linq;

    class P10_RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();
            char[,] matrix = new char[sizes[0], sizes[1]];
            int[] position = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = elements[i];
                    if (elements[i] == 'P')
                    {
                        position[0] = row;
                        position[1] = i;
                    }
                }
            }

            bool isAlive = true;
            bool hasWon = false;
            char[] moves = Console.ReadLine().ToCharArray();

            for (int move = 0; move < moves.Length; move++)
            {
                switch (moves[move])
                {
                    case 'U':
                        if (position[0] - 1 >= 0)
                        {
                            if (matrix[position[0] - 1, position[1]] == 'B')
                            {
                                isAlive = false;
                            }
                            else
                            {
                                matrix[position[0] - 1, position[1]] = 'P';
                            }
                            matrix[position[0], position[1]] = '.';
                            position[0] -= 1;
                        }
                        else
                        {
                            hasWon = true;
                            matrix[position[0], position[1]] = '.';
                        }
                        break;

                    case 'D':
                        if (position[0] + 1 < matrix.GetLength(0))
                        {
                            if (matrix[position[0] + 1, position[1]] == 'B')
                            {
                                isAlive = false;
                            }
                            else
                            {
                                matrix[position[0] + 1, position[1]] = 'P';
                            }
                            matrix[position[0], position[1]] = '.';
                            position[0] += 1;
                        }
                        else
                        {
                            hasWon = true;
                            matrix[position[0], position[1]] = '.';
                        }
                        break;

                    case 'L':
                        if (position[1] - 1 >= 0)
                        {
                            if (matrix[position[0], position[1] - 1] == 'B')
                            {
                                isAlive = false;
                            }
                            else
                            {
                                matrix[position[0], position[1] - 1] = 'P';
                            }
                            matrix[position[0], position[1]] = '.';
                            position[1] -= 1;
                        }
                        else
                        {
                            hasWon = true;
                            matrix[position[0], position[1]] = '.';
                        }
                        break;

                    case 'R':
                        if (position[1] + 1 < matrix.GetLength(1))
                        {
                            if (matrix[position[0], position[1] + 1] == 'B')
                            {
                                isAlive = false;
                            }
                            else
                            {
                                matrix[position[0], position[1] + 1] = 'P';
                            }
                            matrix[position[0], position[1]] = '.';
                            position[1] += 1;
                        }
                        else
                        {
                            matrix[position[0], position[1]] = '.';
                            hasWon = true;
                        }
                        break;
                }

                char[,] matrixCopy = (char[,])matrix.Clone();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        if (matrix[row, i] == 'B')
                        {
                            if (row - 1 >= 0)
                            {
                                if (matrix[row - 1, i] == 'P')
                                {
                                    isAlive = false;
                                }
                                matrixCopy[row - 1, i] = 'B';
                            }
                            if (row + 1 < matrix.GetLength(0))
                            {
                                if (matrix[row + 1, i] == 'P')
                                {
                                    isAlive = false;
                                }
                                matrixCopy[row + 1, i] = 'B';
                            }
                            if (i - 1 >= 0)
                            {
                                if (matrix[row, i - 1] == 'P')
                                {
                                    isAlive = false;
                                }
                                matrixCopy[row, i - 1] = 'B';
                            }
                            if (i + 1 < matrix.GetLength(1))
                            {
                                if (matrix[row, i + 1] == 'P')
                                {
                                    isAlive = false;
                                }
                                matrixCopy[row, i + 1] = 'B';
                            }
                        }
                    }
                }

                matrix = (char[,])matrixCopy.Clone();
                if (isAlive == false)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        string line = string.Empty;
                        for (int i = 0; i < matrix.GetLength(1); i++)
                        {
                            line += matrix[row, i];
                        }
                        Console.WriteLine(line);
                    }
                    Console.WriteLine($"dead: {position[0]} {position[1]}");
                    return;
                }

                if (hasWon)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        string line = string.Empty;
                        for (int i = 0; i < matrix.GetLength(1); i++)
                        {
                            line += matrix[row, i];
                        }
                        Console.WriteLine(line);
                    }
                    Console.WriteLine($"won: {position[0]} {position[1]}");
                    return;
                }
            }
        }
    }
}