namespace P01_CountCharsInAString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P01_CountCharsInAString
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();
            string symbols = Console.ReadLine();

            foreach (char symbol in symbols)
            {
                if (symbol == ' ')
                {
                    continue;
                }

                if (!charCounts.ContainsKey(symbol))
                {
                    charCounts.Add(symbol, 0);
                }
                charCounts[symbol]++;
            }

            foreach (var symbol in charCounts)
            {
                Console.WriteLine($"{symbol.Key} -> {symbol.Value}");
            }
        }
    }
}