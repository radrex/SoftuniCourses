namespace P07_TheVLogger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P07_TheVLogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string[] tokens = Console.ReadLine().Split(' ');

            while (tokens[0] != "Statistics")
            {
                string vlogger = tokens[0];
                string command = tokens[1];
                switch (command)
                {
                    case "joined":
                        if (!vloggers.ContainsKey(vlogger))
                        {
                            vloggers.Add(vlogger, new Dictionary<string, SortedSet<string>>());
                            vloggers[vlogger].Add("followers", new SortedSet<string>());
                            vloggers[vlogger].Add("following", new SortedSet<string>());
                        }
                        break;
                    case "followed":
                        string follower = tokens[2];
                        if (follower != vlogger && vloggers.ContainsKey(vlogger) && vloggers.ContainsKey(follower))
                        {
                            vloggers[vlogger]["following"].Add(follower);
                            vloggers[follower]["followers"].Add(vlogger);
                        }
                        break;
                    default:
                        break;
                }
                tokens = Console.ReadLine().Split(' ');
            }

            int counter = 1;
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            foreach (var vlogger in vloggers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (counter == 1)
                {
                    Console.WriteLine("*  " + String.Join(Environment.NewLine + "*  ", vlogger.Value["followers"]));
                }
                counter++;
            }
        }
    }
}