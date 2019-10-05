namespace P09_Miner
{
    using System;
    using System.Linq;

    class P09_Miner
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            string[] moves = Console.ReadLine().Split();

            int coals = 0;
            int[] position = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine()
                                         .Split()
                                         .Select(char.Parse)
                                         .ToArray();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = elements[i];
                    if (elements[i] == 'c')
                    {
                        coals++;
                    }
                    else if (elements[i] == 's')
                    {
                        position[0] = row;
                        position[1] = i;
                    }
                }
            }

            int collectedCoals = 0;
            for (int move = 0; move < moves.Length; move++)
            {
                switch (moves[move])
                {
                    case "up":
                        if (position[0] - 1 >= 0)
                        {
                            position[0] -= 1;
                            if (matrix[position[0], position[1]] == 'c')
                            {
                                matrix[position[0], position[1]] = '*';
                                coals--;
                                collectedCoals++;
                            }
                            else if (matrix[position[0], position[1]] == 'e')
                            {
                                Console.WriteLine($"Game over! ({position[0]}, {position[1]})");
                                return;
                            }
                        }
                        break;

                    case "down":
                        if (position[0] + 1 < matrix.GetLength(0))
                        {
                            position[0] += 1;
                            if (matrix[position[0], position[1]] == 'c')
                            {
                                matrix[position[0], position[1]] = '*';
                                coals--;
                                collectedCoals++;
                            }
                            else if (matrix[position[0], position[1]] == 'e')
                            {
                                Console.WriteLine($"Game over! ({position[0]}, {position[1]})");
                                return;
                            }
                        }
                        break;

                    case "left":
                        if (position[1] - 1 >= 0)
                        {
                            position[1] -= 1;
                            if (matrix[position[0], position[1]] == 'c')
                            {
                                matrix[position[0], position[1]] = '*';
                                coals--;
                                collectedCoals++;
                            }
                            else if (matrix[position[0], position[1]] == 'e')
                            {
                                Console.WriteLine($"Game over! ({position[0]}, {position[1]})");
                                return;
                            }
                        }
                        break;

                    case "right":
                        if (position[1] + 1 < matrix.GetLength(1))
                        {
                            position[1] += 1;
                            if (matrix[position[0], position[1]] == 'c')
                            {
                                matrix[position[0], position[1]] = '*';
                                coals--;
                                collectedCoals++;
                            }
                            else if (matrix[position[0], position[1]] == 'e')
                            {
                                Console.WriteLine($"Game over! ({position[0]}, {position[1]})");
                                return;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(coals == 0 ? $"You collected all coals! ({position[0]}, {position[1]})" : 
                                           $"{coals} coals left. ({position[0]}, {position[1]})");
        }
    }
}
