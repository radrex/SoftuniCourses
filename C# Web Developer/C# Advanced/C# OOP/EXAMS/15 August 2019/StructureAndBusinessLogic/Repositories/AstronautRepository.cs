namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        //------------- Fields --------------
        private Dictionary<string, IAstronaut> models;

        //---------- Constructors -----------
        public AstronautRepository()
        {
            this.models = new Dictionary<string, IAstronaut>();
        }

        //----------- Properties ------------
        public IReadOnlyCollection<IAstronaut> Models => this.models.Values.ToList().AsReadOnly();

        //------------ Methods --------------
        public void Add(IAstronaut model)
        {
            if (!this.models.ContainsKey(model.Name))
            {
                this.models.Add(model.Name, model);
            }
        }

        public IAstronaut FindByName(string name)
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

        public bool Remove(IAstronaut model)
        {
            return this.models.Remove(model.Name);
        }
    }
}
