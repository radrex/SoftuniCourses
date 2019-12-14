namespace ViceCity.Models.Players
{
    using System;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;
    using ViceCity.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        //-------------- Fields ---------------
        private string name;
        private int lifePoints;

        //----------- Constructors ------------
        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository<IGun>();
        }

        //------------ Properties -------------
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }

                this.name = value;
            }
        }

        public bool IsAlive => this.LifePoints > 0;

        public IRepository<IGun> GunRepository { get; }

        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                this.lifePoints = value;
            }
        }

        //-------------- Methods --------------
        public void TakeLifePoints(int points)
        {
            if (points >= this.LifePoints)
            {
                this.LifePoints = 0;
            }
            else
            {
                this.LifePoints -= points;
            }
        }
    }
}
