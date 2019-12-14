namespace ViceCity.Models.Guns
{
    using System;
    using ViceCity.Models.Guns.Contracts;

    public abstract class Gun : IGun
    {
        //-------------- Fields ---------------
        private string name;
        private int bulltesPerBarrel;
        private int totalBullets;

        //----------- Constructors ------------
        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        //------------ Properties -------------
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulltesPerBarrel;
            private protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }

                this.bulltesPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;
            private protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.TotalBullets > 0;

        //-------------- Methods --------------
        public abstract int Fire();
    }
}
