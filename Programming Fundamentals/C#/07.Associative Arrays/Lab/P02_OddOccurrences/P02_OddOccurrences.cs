namespace P02_OddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_OddOccurrences
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!counts.ContainsKey(word.ToLower()))
                {
                    counts.Add(word.ToLower(), 1);
                }
                else
                {
                    counts[word.ToLower()]++;
                }
            }

            string message = string.Empty;
            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    message += $"{count.Key} ";
                }
            }

            Console.WriteLine(message.TrimEnd());
        }
    }
}