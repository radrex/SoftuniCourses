namespace P03_WordCount
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class P03_WordCount
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("words.txt");
            var lineWords = File.ReadAllLines("text.txt")
                                .Select(line => Regex.Matches(line, @"[A-Za-z']*[A-Za-z]{1}")
                                                     .Cast<Match>()
                                                     .Select(word => word.Value.ToLower())
                                                     .ToArray());
            StringBuilder sb = new StringBuilder();
            foreach (string word in words)
            {
                int counter = 0;
                foreach (string[] line in lineWords)
                {
                    foreach (string currentWord in line)
                    {
                        if (word == currentWord)
                        {
                            counter++;
                        }
                    }
                }
                sb.AppendLine($"{word} - {counter}");
            }
            File.WriteAllText("../../../actualResult.txt", sb.ToString());
            sb.Clear();

            string[] orderedWords = File.ReadAllLines("actualResult.txt");
            foreach (string word in orderedWords.OrderByDescending(x => x.Substring(x.Length - 1, 1)))
            {
                sb.AppendLine(word);
            }
            File.WriteAllText("../../../expectedResult.txt", sb.ToString());
        }
    }
}
