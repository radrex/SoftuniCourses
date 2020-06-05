namespace P03_MOBAChallenger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P03_MOBAChallenger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();
            string[] command = Console.ReadLine().Split(new string[] { "->", "vs" }, StringSplitOptions.RemoveEmptyEntries)
                                                 .Select(x => x.Trim()).ToArray();
            while (command[0] != "Season end")
            {
                if (command.Length == 3)
                {
                    string player = command[0];
                    string role = command[1];
                    int points = int.Parse(command[2]);

                    if (!players.ContainsKey(player))
                    {
                        players.Add(player, new Dictionary<string, int>() { { role, points } });
                    }
                    else
                    {
                        if (!players[player].ContainsKey(role))
                        {
                            players[player].Add(role, points);
                        }
                        else if (players[player][role] <= points)
                        {
                            players[player][role] = points;
                        }
                    }
                }
                else
                {
                    string firstPlayer = command[0];
                    string secondPlayer = command[1];

                    if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer))
                    {
                        if (players[firstPlayer].Any(p => players[secondPlayer].ContainsKey(p.Key)))
                        {
                            if (players[firstPlayer].Sum(p => p.Value) > players[secondPlayer].Sum(p => p.Value))
                            {
                                players.Remove(secondPlayer);
                            }
                            else
                            {
                                players.Remove(firstPlayer);
                            }
                        }
                    }
                }

                command = Console.ReadLine().Split(new string[] { "->", "vs" }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(x => x.Trim()).ToArray();
            }

            foreach (var player in players.OrderByDescending(p => p.Value.Values.Sum()).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");
                foreach (var role in player.Value.OrderByDescending(r => r.Value).ThenBy(r => r.Key))
                {
                    Console.WriteLine($"- {role.Key} <::> {role.Value}");
                }
            }
        }
    }
}