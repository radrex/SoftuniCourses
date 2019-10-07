namespace P08_Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P08_Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, SortedDictionary<string, int>> candidates = new SortedDictionary<string, SortedDictionary<string, int>>();
            string[] contestInfo = Console.ReadLine().Split(':');

            while (contestInfo[0] != "end of contests")
            {
                string contest = contestInfo[0];
                string password = contestInfo[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                contestInfo = Console.ReadLine().Split(':');
            }

            string[] candidatesInfo = Console.ReadLine().Split("=>");
            while (candidatesInfo[0] != "end of submissions")
            {
                string contest = candidatesInfo[0];
                string password = candidatesInfo[1];
                string candidate = candidatesInfo[2];
                int points = int.Parse(candidatesInfo[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!candidates.ContainsKey(candidate))
                    {
                        candidates.Add(candidate, new SortedDictionary<string, int>());
                    }
                    if (!candidates[candidate].ContainsKey(contest))
                    {
                        candidates[candidate].Add(contest, points);
                    }
                    else if (candidates[candidate][contest] < points)
                    {
                        candidates[candidate][contest] = points;
                    }
                }

                candidatesInfo = Console.ReadLine().Split("=>");
            }

            var topCandidate = candidates.OrderByDescending(candidate => candidate.Value.Sum(points => points.Value)).First();
            Console.WriteLine($"Best candidate is {topCandidate.Key} with total {topCandidate.Value.Sum(s => s.Value)} points.");
            Console.WriteLine("Ranking:");
            foreach (var candidate in candidates)
            {
                Console.WriteLine(candidate.Key);
                foreach (var contest in candidate.Value)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}