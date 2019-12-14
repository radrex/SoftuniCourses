namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts.Where(a => a.CanBreath))
            {
                while (planet.Items.Count != 0)
                {
                    astronaut.Bag.Items.Add(planet.Items.First());
                    planet.Items.Remove(planet.Items.First());
                    astronaut.Breath();

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }
            }
        }
    }
}
