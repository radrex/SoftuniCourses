namespace P04_StarEnigma
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class P04_StarEnigma
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                string decrypted = string.Empty;
                MatchCollection matches = Regex.Matches(message, @"[STARstar]");

                for (int k = 0; k < message.Length; k++)
                {
                    decrypted += (char)(message[k] - matches.Count);
                }

                string pattern = @"@[^@\-!:>]*?(?<planet>[A-Z][a-z]+)[^@\-!:>]*?:[^@\-!:>]*?(?<population>\d+)[^@\-!:>]*?![^@\-!:>]*?(?<attackType>[AD])[^@\-!:>]*?![^@\-!:>]*?->[^@\-!:>]*?(?<soldiers>\d+)[^@\-!:>]*?";

                Match planet = Regex.Match(decrypted, pattern);
                if (planet.Groups["attackType"].Value == "A")
                {
                    attackedPlanets.Add(planet.Groups["planet"].Value);
                }
                else if (planet.Groups["attackType"].Value == "D")
                {
                    destroyedPlanets.Add(planet.Groups["planet"].Value);
                }                
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
