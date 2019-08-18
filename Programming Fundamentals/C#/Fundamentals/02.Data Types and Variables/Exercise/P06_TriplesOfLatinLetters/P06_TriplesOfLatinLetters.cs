namespace P06_TriplesOfLatinLetters
{
    using System;

    class P06_TriplesOfLatinLetters
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int c1 = 97; c1 < 97 + n; c1++)
            {
                for (int c2 = 97; c2 < 97 + n; c2++)
                {
                    for (int c3 = 97; c3 < 97 + n; c3++)
                    {
                        Console.WriteLine($"{(char)c1}{(char)c2}{(char)c3}");
                    }
                }
            }
        }
    }
}