namespace P04_PrintingTriangle
{
    using System;

    class P04_PrintingTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }

        public static void PrintTriangle(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintLine(1, i);
            }

            for (int i = number - 1; i >= 1; i--)
            {
                PrintLine(1, i);
            }
        }

        public static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}