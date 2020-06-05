namespace P10_SoftUniExamResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P10_SoftUniExamResults
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> users = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();

            string command = Console.ReadLine();
            while (command != "exam finished")
            {
                string[] tokens = command.Split('-');
                string username = tokens[0];
                string language = tokens[1];

                if (language == "banned")
                {
                    users.Remove(username);
                    command = Console.ReadLine();
                    continue;
                }

                int points = int.Parse(tokens[2]);
                //------------------ Language Dictionary --------------------
                if (!languages.ContainsKey(language))
                {
                    languages.Add(language, 1);
                }
                else
                {
                    languages[language]++;
                }
                //------------------ Username Dictionary --------------------
                if (!users.ContainsKey(username))
                {
                    users.Add(username, points);
                }
                else
                {
                    if (users[username] <= points)
                    {
                        users[username] = points;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var user in users.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in languages.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}