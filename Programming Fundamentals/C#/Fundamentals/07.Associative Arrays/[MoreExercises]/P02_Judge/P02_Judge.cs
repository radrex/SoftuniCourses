namespace P02_Judge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_Judge
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();
            string[] command = Console.ReadLine()
                                      .Split("->", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(x => x.Trim()).ToArray();
            while (command[0] != "no more time")
            {
                string username = command[0];
                string contest = command[1];
                int points = int.Parse(command[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new Dictionary<string, int>() { { username, points } });
                }
                else
                {
                    if (!contests[contest].ContainsKey(username))
                    {
                        contests[contest].Add(username, points);
                    }
                    else if (contests[contest][username] < points)
                    {
                        contests[contest][username] = points;
                    }
                }

                command = Console.ReadLine()
                                 .Split("->", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(x => x.Trim()).ToArray();
            }

            List<KeyValuePair<string, int>> individualStandings = contests.SelectMany(x => x.Value).ToList();
            Dictionary<string, int> sortedIndividualStandings = new Dictionary<string, int>();
            foreach (var user in individualStandings)
            {
                if (!sortedIndividualStandings.ContainsKey(user.Key))
                {
                    sortedIndividualStandings.Add(user.Key, user.Value);
                }
                else
                {
                    sortedIndividualStandings[user.Key] += user.Value;
                }
            }

            //-------------------------- Printing -------------------------------
            int count = 0;
            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count()} participants");
                foreach (var username in contest.Value.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
                {
                    Console.WriteLine($"{++count}. {username.Key} <::> {username.Value}");
                }
                count = 0;
            }

            Console.WriteLine("Individual standings:");
            foreach (var user in sortedIndividualStandings.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                Console.WriteLine($"{++count}. {user.Key} -> {user.Value}");
            }
        }
    }
}