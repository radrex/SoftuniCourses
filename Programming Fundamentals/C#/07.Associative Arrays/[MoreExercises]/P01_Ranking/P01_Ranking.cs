namespace P01_Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P01_Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> candidateInterns = new Dictionary<string, Dictionary<string, int>>();

            string[] data = Console.ReadLine().Split(':');
            while (data[0] != "end of contests")
            {
                string contest = data[0];
                string password = data[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
                else
                {
                    contests[contest] = password;
                }

                data = Console.ReadLine().Split(':');
            }

            data = Console.ReadLine().Split("=>");
            while (data[0] != "end of submissions")
            {
                string contest = data[0];
                string password = data[1];
                string candidate = data[2];
                int points = int.Parse(data[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {

                    if (!candidateInterns.ContainsKey(candidate))
                    {
                        candidateInterns.Add(candidate, new Dictionary<string, int>());
                        candidateInterns[candidate].Add(contest, points);
                    }
                    else
                    {
                        if (!candidateInterns[candidate].ContainsKey(contest))
                        {
                            candidateInterns[candidate].Add(contest, points);
                        }
                        else if (candidateInterns[candidate][contest] <= points)
                        {
                            candidateInterns[candidate][contest] = points;
                        }
                    }
                }

                data = Console.ReadLine().Split("=>");
            }

            var bestCandidate = candidateInterns.Select(c => new KeyValuePair<string, int>(c.Key, c.Value.Values.Sum()))
                                                .OrderByDescending(c => c.Value)
                                                .First();
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value} points.");
            Console.WriteLine("Ranking: ");
            foreach (var candidate in candidateInterns.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{candidate.Key}");
                foreach (var course in candidate.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}