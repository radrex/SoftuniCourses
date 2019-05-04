namespace P02_NumberPyramid
{
    using System;

    class P02_NumberPyramid
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int current = 1;
            bool isBigger = false;

            for (int i = 1; i <= n; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    if (current > n)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write(current + " ");
                    current++;
                }

                if (isBigger)
                {
                    break;
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
