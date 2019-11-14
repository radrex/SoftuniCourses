namespace P05_FootballTeamGenerator.Models
{
    using System;

    public class Player
    {
        //-------------------------- Fields ------------------------------
        private string name;

        //------------------------ Constructors --------------------------
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        //------------------------- Properties ---------------------------
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public Stats Stats { get; private set; }

        public double Skill => (this.Stats.Endurance + this.Stats.Sprint + this.Stats.Dribble + this.Stats.Passing + this.Stats.Shooting) / 5.0;
    }
}
