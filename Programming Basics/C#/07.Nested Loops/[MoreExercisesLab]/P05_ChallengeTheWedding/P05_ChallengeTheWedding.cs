namespace P05_ChallengeTheWedding
{
    using System;

    class P05_ChallengeTheWedding
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());

            for (int i = 1; i <= men; i++)
            {
                for (int k = 1; k <= women; k++)
                {
                    if (tables > 0)
                    {
                        Console.Write($"({i} <-> {k}) ");
                    }

                    tables--;
                }
            }

            Console.WriteLine();
        }
    }
}
