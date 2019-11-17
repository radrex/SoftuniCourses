namespace P05_BorderControl
{
    using System;
    using System.Collections.Generic;

    public class City
    {
        //--------------- Fields -----------------
        private List<Citizen> citizens;
        private List<Robot> robots;
        private List<string> detainedIds;

        //------------- Constructors -------------
        public City()
        {
            this.citizens = new List<Citizen>();
            this.robots = new List<Robot>();
            this.detainedIds = new List<string>();
        }

        //-------------- Properties --------------
        public IReadOnlyCollection<Citizen> Citizens => this.citizens;
        public IReadOnlyCollection<Robot> Robots => this.robots;
        public IReadOnlyCollection<string> DetainedIds => this.detainedIds;

        //------------ Public Methods ------------
        public void AddCitizen(Citizen citizen)
        {
            this.citizens.Add(citizen);
            this.detainedIds.Add(citizen.Id);
        }

        public void AddRobot(Robot robot)
        {
            this.robots.Add(robot);
            this.detainedIds.Add(robot.Id);
        }

        public void DetainRebels(string filter)
        {
            Predicate<string> predicate = id => id.EndsWith(filter);

            this.detainedIds.RemoveAll(x => !predicate(x));
            this.citizens.RemoveAll(c => predicate(c.Id));
            this.robots.RemoveAll(r => predicate(r.Id));
        }

        public override string ToString()
        {
            return $"{String.Join(Environment.NewLine, detainedIds)}";
        }
    }
}
