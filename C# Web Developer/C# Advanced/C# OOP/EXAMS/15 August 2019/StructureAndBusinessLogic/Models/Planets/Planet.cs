namespace SpaceStation.Models.Planets
{
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Planet : IPlanet
    {
        //------------- Fields --------------
        private string name;
        private ICollection<string> items;

        //---------- Constructors -----------
        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }

        //----------- Properties ------------
        public ICollection<string> Items => this.items;

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }
    }
}
