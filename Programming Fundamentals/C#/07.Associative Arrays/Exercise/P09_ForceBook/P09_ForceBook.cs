namespace P09_ForceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P09_ForceBook
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceFighters = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command != "Lumpawaroo")
            {
                string force = string.Empty;
                string fighter = string.Empty;

                if (command.Contains('|'))
                {
                    string[] tokens = command.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                    force = tokens[0];
                    fighter = tokens[1];

                    if (!forceFighters.ContainsKey(force))
                    {
                        forceFighters.Add(force, new List<string>());
                    }

                    if (!forceFighters[force].Contains(fighter) && !forceFighters.Values.Any(f => f.Contains(fighter)))
                    {
                        forceFighters[force].Add(fighter);
                    }
                }
                else if (command.Contains("->"))
                {
                    string[] tokens = command.Split("->", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                    fighter = tokens[0];
                    force = tokens[1];

                    if (!forceFighters.ContainsKey(force))
                    {
                        forceFighters.Add(force, new List<string>());
                    }

                    if (!forceFighters.Any(f => f.Value.Contains(fighter)))
                    {
                        forceFighters[force].Add(fighter);
                    }
                    else
                    {
                        foreach (List<string> fighters in forceFighters.Values)
                        {
                            fighters.Remove(fighter);
                        }

                        forceFighters[force].Add(fighter);
                    }

                    Console.WriteLine($"{fighter} joins the {force} side!");
                }

                command = Console.ReadLine();
            }

            foreach (var force in forceFighters.Where(f => f.Value.Count > 0).OrderByDescending(f => f.Value.Count()).ThenBy(f => f.Key))
            {
                Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count()}");
                force.Value.OrderBy(f => f).ToList().ForEach(fighter => Console.WriteLine($"! {fighter}"));
            }
        }
    }
}