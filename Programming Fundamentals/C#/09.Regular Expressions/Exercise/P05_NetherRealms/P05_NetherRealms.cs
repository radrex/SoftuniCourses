namespace P05_NetherRealms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class P05_NetherRealms
    {
        static void Main(string[] args)
        {
            List<Tuple<string, int, decimal>> demons = new List<Tuple<string, int, decimal>>();
            string[] tokens = Console.ReadLine()
                                     .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(x => x.Trim())
                                     .ToArray();

            for (int i = 0; i < tokens.Length; i++)
            {
                int totalHealth = 0;
                MatchCollection matches = Regex.Matches(tokens[i], @"[^\d+\-*\/.]");
                foreach (Match match in matches)
                {
                    totalHealth += char.Parse(match.Value);
                }

                matches = Regex.Matches(tokens[i], @"[-+]?[\d\.]*\d");
                decimal baseDmg = 0;
                foreach (Match match in matches)
                {
                    baseDmg += decimal.Parse(match.Value);
                }

                matches = Regex.Matches(tokens[i], @"[*\/]");
                foreach (Match match in matches)
                {
                    if (match.Value == "*")
                    {
                        baseDmg *= 2;
                    }
                    else if (match.Value == "/")
                    {
                        baseDmg /= 2;
                    }
                }

                demons.Add(new Tuple<string, int, decimal>(tokens[i], totalHealth, baseDmg));
            }

            foreach (Tuple<string, int, decimal> demon in demons.OrderBy(x => x))
            {
                Console.WriteLine($"{demon.Item1} - {demon.Item2} health, {demon.Item3:F2} damage");
            }
        }
    }
}
