namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Utilities.Messages;
    using System;

    public abstract class Astronaut : IAstronaut
    {
        //------------- Fields --------------
        private string name;
        private double oxygen;
        private IBag backpack;

        //---------- Constructors -----------
        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.backpack = new Backpack();
        }

        //----------- Properties ------------
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            private protected set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag => this.backpack;

        //------------ Methods --------------
        public virtual void Breath()
        {
            if (this.Oxygen >= 10)
            {
                this.Oxygen -= 10;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
