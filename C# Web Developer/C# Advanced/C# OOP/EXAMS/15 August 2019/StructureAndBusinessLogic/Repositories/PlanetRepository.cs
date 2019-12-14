namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        //------------- Fields --------------
        private Dictionary<string, IPlanet> models;

        //---------- Constructors -----------
        public PlanetRepository()
        {
            this.models = new Dictionary<string, IPlanet>();
        }

        //----------- Properties ------------
        public IReadOnlyCollection<IPlanet> Models => this.models.Values.ToList().AsReadOnly();

        //------------ Methods --------------
        public void Add(IPlanet model)
        {
            if (!this.models.ContainsKey(model.Name))
            {
                this.models.Add(model.Name, model);
            }
        }

        public IPlanet FindByName(string name)
        {
            if (this.models.ContainsKey(name))
            {
                return this.models[name];
            }
            else
            {
                return null;
            }
        }

        public bool Remove(IPlanet model)
        {
            return this.models.Remove(model.Name);
        }
    }
}
