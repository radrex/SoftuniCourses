namespace P05_FootballTeamGenerator.Core
{
    using P05_FootballTeamGenerator.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        //-------------------------- Fields ------------------------------
        private List<Team> teams;

        //------------------------ Constructors --------------------------
        public Engine()
        {
            this.teams = new List<Team>();
        }

        //-------------------------- Methods -----------------------------
        public void Run()
        {
            string[] commands = Console.ReadLine().Split(';');
            while (commands[0] != "END")
            {
                switch (commands[0])
                {
                    case "Team":
                        if (!TeamExists(commands[1]))
                        {
                            this.teams.Add(new Team(commands[1]));
                        }
                        break;

                    case "Add":
                        if (!TeamExists(commands[1]))
                        {
                            Console.WriteLine($"Team {commands[1]} does not exist.");
                        }
                        else
                        {
                            Team team = this.teams.First(t => t.Name == commands[1]);
                            try
                            {
                                Stats stats = new Stats(int.Parse(commands[3]), int.Parse(commands[4]), int.Parse(commands[5]), int.Parse(commands[6]), int.Parse(commands[7]));
                                Player player = new Player(commands[2], stats);
                                team.AddPlayer(player);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case "Remove":
                        if (TeamExists(commands[1]))
                        {
                            Team team = this.teams.First(t => t.Name == commands[1]);
                            try
                            {
                                team.RemovePlayer(commands[2]);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case "Rating":
                        if (!TeamExists(commands[1]))
                        {
                            Console.WriteLine($"Team {commands[1]} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine(this.teams.First(t => t.Name == commands[1]).ToString());
                        }
                        break;

                    default:
                        break;
                }

                commands = Console.ReadLine().Split(';');
            }
        }

        private bool TeamExists(string teamName)
        {
            return this.teams.Any(t => t.Name == teamName);
        }
    }
}
