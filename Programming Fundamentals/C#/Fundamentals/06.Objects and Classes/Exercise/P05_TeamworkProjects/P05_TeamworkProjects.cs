namespace P05_TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P05_TeamworkProjects
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] createTeamData = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                string playerName = createTeamData[0];
                string teamName = createTeamData[1];

                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(t => t.Creator.Name == playerName))
                {
                    Console.WriteLine($"{playerName} cannot create another team!");
                }
                else
                {
                    Player player = new Player()
                    {
                        Name = playerName
                    };

                    Team team = new Team()
                    {
                        Name = teamName,
                        Creator = player
                    };

                    teams.Add(team);
                    Console.WriteLine($"Team {team.Name} has been created by {player.Name}!");
                }
            }


            string[] joinCommand = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);
            while (joinCommand[0] != "end of assignment")
            {
                string playerName = joinCommand[0];
                string teamName = joinCommand[1];

                if (!teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(t => t.Creator.Name == playerName || t.Players.Any(p => p.Name == playerName)))
                {
                    Console.WriteLine($"Member {playerName} cannot join team {teamName}!");
                }
                else
                {
                    Player player = new Player()
                    {
                        Name = playerName
                    };

                    teams.First(t => t.Name == teamName).Players.Add(player);
                }

                joinCommand = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (Team team in teams.Where(t => t.Players.Count != 0).OrderByDescending(t => t.Players.Count).ThenBy(t => t.Name))
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator.Name}");
                foreach (Player player in team.Players.OrderBy(p => p.Name))
                {
                    Console.WriteLine($"-- {player.Name}");
                }
            }

            Console.WriteLine("Teams to disband:");


            teams.Where(t => t.Players.Count == 0).OrderBy(t => t.Name).ToList().ForEach(t => Console.WriteLine(t.Name));

            //foreach (Team team in teams.Where(t => t.Players.Count == 0).OrderBy(t => t.Name))
            //{
            //    Console.WriteLine(team.Name);
            //}
        }
    }

    class Team
    {
        public Team()
        {
            this.Players = new List<Player>();
        }

        public string Name { get; set; }
        public Player Creator { get; set; }
        public List<Player> Players { get; set; }
    }

    class Player
    {
        public string Name { get; set; }
    }
}