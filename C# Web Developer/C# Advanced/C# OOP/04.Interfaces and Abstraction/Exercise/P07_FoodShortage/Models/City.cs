namespace P07_FoodShortage.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class City
    {
        //--------------- Fields -----------------
        private List<Citizen> citizens;
        private List<Rebel> rebels;

        //------------- Constructors -------------
        public City()
        {
            this.citizens = new List<Citizen>();
            this.rebels = new List<Rebel>();
        }

        //-------------- Properties --------------
        public IReadOnlyCollection<Citizen> Citizens => this.citizens;
        public IReadOnlyCollection<Rebel> Rebels => this.rebels;

        //------------ Public Methods ------------
        public void AddCitizen(Citizen citizen)
        {
            this.citizens.Add(citizen);
        }

        public void AddRebel(Rebel rebel)
        {
            this.rebels.Add(rebel);
        }
    }
}
