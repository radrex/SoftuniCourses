namespace P05_CountSymbols
{
    using System;
    using System.Collections.Generic;

    class P05_CountSymbols
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            string input = Console.ReadLine();

            foreach (char symbol in input)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 1);
                }
                else
                {
                    symbols[symbol]++;
                }
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine(String.Join(Environment.NewLine, $"{symbol.Key}: {symbol.Value} time/s"));
            }
        }
    }
}
