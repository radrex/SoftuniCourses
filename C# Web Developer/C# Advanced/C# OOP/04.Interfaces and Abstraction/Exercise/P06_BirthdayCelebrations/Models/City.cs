namespace P06_BirthdayCelebrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class City
    {
        //--------------- Fields -----------------
        private List<Citizen> citizens;
        private List<Robot> robots;
        private List<Pet> pets;

        //------------- Constructors -------------
        public City()
        {
            this.citizens = new List<Citizen>();
            this.robots = new List<Robot>();
            this.pets = new List<Pet>();
        }

        //-------------- Properties --------------
        public IReadOnlyCollection<Citizen> Citizens => this.citizens;
        public IReadOnlyCollection<Robot> Robots => this.robots;
        public IReadOnlyCollection<Pet> Pets => this.pets;

        //------------ Public Methods ------------
        public void AddCitizen(Citizen citizen)
        {
            this.citizens.Add(citizen);
        }

        public void AddRobot(Robot robot)
        {
            this.robots.Add(robot);
        }

        public void AddPet(Pet pet)
        {
            this.pets.Add(pet);
        }

        public void PrintBirthdates(string year)
        {
            Predicate<string> predicate = y => y.EndsWith(year);
            this.Citizens.Where(c => predicate(c.Birthdate)).ToList().ForEach(x => Console.WriteLine(x.Birthdate));
            this.Pets.Where(p => predicate(p.Birthdate)).ToList().ForEach(x => Console.WriteLine(x.Birthdate));
        }
    }
}
