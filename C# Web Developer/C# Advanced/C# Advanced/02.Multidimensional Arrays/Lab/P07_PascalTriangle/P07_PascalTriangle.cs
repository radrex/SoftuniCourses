namespace P07_PascalTriangle
{
    using System;

    class P07_PascalTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jagged = new long[n][];

            for (int row = 0; row < jagged.Length; row++)
            {
                jagged[row] = new long[row + 1];
                jagged[row][0] = 1; // FIRST ELEMENT ALWAYS -> 1
                jagged[row][row] = 1;
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                if (jagged[row].Length > 2)
                {
                    for (int i = 1; i < jagged[row].Length - 1; i++)
                    {
                        jagged[row][i] = jagged[row - 1][i] + jagged[row - 1][i - 1];
                    }
                }
            }

            foreach (long[] number in jagged)
            {
                Console.WriteLine(String.Join(" ", number));
            }
        }
    }
}
