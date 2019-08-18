namespace P03_WordSynonyms
{
    using System;
    using System.Collections.Generic;

    class P03_WordSynonyms
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordSynonyms = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string key = Console.ReadLine();
                string value = Console.ReadLine();

                if (!wordSynonyms.ContainsKey(key))
                {
                    wordSynonyms.Add(key, new List<string>());
                }

                wordSynonyms[key].Add(value);
            }

            foreach (var word in wordSynonyms)
            {
                Console.WriteLine($"{word.Key} - {String.Join(", ", word.Value)}");
            }
        }
    }
}