namespace P07_KnightGame
{
    using System;

    class P07_KnightGame
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i] = rowElements[i];
                }
            }                                                             //       i   i   i   i   i    
                                                                          //       0   1   2   3   4   COL
            int attackableKnights = 0;                                    // ROW ---------------------                                      
            int maxAttackableKnights = -1;                                //  0  |   | X |   | X |   |      K --> Knight
            int bestKnightRow = 0;                                        //  1  | X |   |   |   | X |      X --> Attackable Unit (Other Knight)
            int bestKnightCol = 0;                                        //  2  |   |   | K |   |   |
            int count = 0;                                                //  3  | X |   |   |   | A |
                                                                          //  4  |   | X |   | X |   |
            while (true)                                                  //     ---------------------
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        if (matrix[row, i] == 'K')
                        {
                            //--------- 1 row UNDER ---------
                            if (row + 1 < matrix.GetLength(0))  
                            {
                                if (i - 2 >= 0)
                                {
                                    if (matrix[row + 1, i - 2] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }

                                if (i + 2 < matrix.GetLength(1))
                                {
                                    if (matrix[row + 1, i + 2] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }
                            }

                            //--------- 1 row UP ---------
                            if (row - 1 >= 0)
                            {
                                if (i - 2 >= 0)
                                {
                                    if (matrix[row - 1, i - 2] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }

                                if (i + 2 < matrix.GetLength(1))
                                {
                                    if (matrix[row - 1, i + 2] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }
                            }
                            //--------- 2 rows UNDER ---------
                            if (row + 2 < matrix.GetLength(0))
                            {
                                if (i + 1 < matrix.GetLength(1))
                                {
                                    if (matrix[row + 2, i + 1] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }

                                if (i - 1 >= 0)
                                {
                                    if (matrix[row + 2, i - 1] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }
                            }

                            //--------- 2 rows UP ---------
                            if (row - 2 >= 0)
                            {
                                if (i + 1 < matrix.GetLength(1))
                                {
                                    if (matrix[row - 2, i + 1] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }

                                if (i - 1 >= 0)
                                {
                                    if (matrix[row - 2, i - 1] == 'K')
                                    {
                                        attackableKnights++;
                                    }
                                }
                            }
                        }

                        if (attackableKnights > maxAttackableKnights)
                        {
                            maxAttackableKnights = attackableKnights;
                            bestKnightRow = row;
                            bestKnightCol = i;
                        }
                        attackableKnights = 0;
                    }
                }

                if (maxAttackableKnights != 0)
                {
                    matrix[bestKnightRow, bestKnightCol] = '0';                 
                    maxAttackableKnights = 0;
                    count++;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }
    }
}
