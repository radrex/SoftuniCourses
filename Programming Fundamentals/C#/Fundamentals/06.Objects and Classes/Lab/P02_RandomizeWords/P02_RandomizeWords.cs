namespace P02_RandomizeWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_RandomizeWords
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                                        .Split()
                                        .ToList();
            Random rnd = new Random();

            while (words.Count != 0)
            {
                int randomIndex = rnd.Next(0, words.Count - 1);
                Console.WriteLine(words[randomIndex]);
                words.RemoveAt(randomIndex);
            }
        }
    }
}
