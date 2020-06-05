namespace P03_PostOffice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class P03_PostOffice
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => x.Trim())
                                    .ToArray();

            string lettersPattern = @"([#$%*&])(?<capLetters>[A-Z]+)(\1)";
            Match lettersMatch = Regex.Match(input[0], lettersPattern);
            string letters = lettersMatch.Groups["capLetters"].Value;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < letters.Length; i++)
            {
                char letter = letters[i];
                int ascii = letter;

                string asciiPattern = $@"{ascii}:(?<length>[0-9][0-9])";
                Match asciiMatch = Regex.Match(input[1], asciiPattern);
                int length = int.Parse(asciiMatch.Groups["length"].Value);

                string wordsPattern = $@"(?<=\s|^){letter}[^\s]{{{length}}}(?=\s|$)";
                Match wordMatch = Regex.Match(input[2], wordsPattern);
                sb.AppendLine(wordMatch.Value);
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
