namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        //-------------- Fields ---------------
        private IRepository<IAstronaut> astronautRepository;
        private IRepository<IPlanet> planetRepository;
        private IMission mission;
        private int exploredPlanets = 0;

        //----------- Constructors ------------
        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        //------------- Methods ---------------
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;

                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;

                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepository.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (string item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();
            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = this.planetRepository.FindByName(planetName);
            this.mission.Explore(planet, suitableAstronauts);

            this.exploredPlanets++;

            return $"Planet: {planetName} was explored! Exploration finished with {suitableAstronauts.Count(a => !a.CanBreath)} dead astronauts!";
        }

        public string Report()
        { 
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.exploredPlanets} planets were explored!");

            sb.AppendLine($"Astronauts info:");
            foreach (IAstronaut astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                string items = astronaut.Bag.Items.Count == 0 ? "none" : String.Join(", ", astronaut.Bag.Items);
                sb.AppendLine($"Bag items: {items}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronautRepository.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
