namespace P02_Race
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class P02_Race
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = new Dictionary<string, int>();
            string[] names = Console.ReadLine()
                                    .Split(", ")
                                    .ToArray();
            foreach (string name in names)
            {
                if (!racers.ContainsKey(name))
                {
                    racers.Add(name, 0);
                }
            }


            string namePattern = @"[A-Za-z]+";
            string distancePattern = @"\d";
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of race")
                {
                    break;
                }

                string name = String.Join("", Regex.Matches(input, namePattern));
                MatchCollection distances = Regex.Matches(input, distancePattern);
                int maxDistance = distances.Sum(x => int.Parse(x.Value));

                if (racers.ContainsKey(name))
                {
                    racers[name] += maxDistance;
                }
            }

            byte place = 1;
            string nth = "st";
            foreach (var racer in racers.OrderByDescending(r => r.Value).Take(3))
            {
                if (place == 2) { nth = "nd"; }
                else if (place == 3) { nth = "rd"; }

                Console.WriteLine($"{place++}{nth} place: {racer.Key}");
            }
        }
    }
}
