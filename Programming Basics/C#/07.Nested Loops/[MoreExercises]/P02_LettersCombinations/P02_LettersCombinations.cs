namespace P02_LettersCombinations
{
    using System;

    class P02_LettersCombinations
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char miss = char.Parse(Console.ReadLine());

            int counter = 0;

            for (char c1 = start; c1 <= end; c1++)
            {
                for (char c2 = start; c2 <= end; c2++)
                {
                    for (char c3 = start; c3 <= end; c3++)
                    {
                        if (c1 != miss && c2 != miss && c3 != miss)
                        {
                            Console.Write($"{c1}{c2}{c3} ");
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
