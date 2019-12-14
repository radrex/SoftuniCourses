namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories.Contracts;

    public class GunRepository<T> : IRepository<IGun>
    {
        //-------------- Fields ---------------
        private Dictionary<string, IGun> guns;

        //----------- Constructors ------------
        public GunRepository()
        {
            this.guns = new Dictionary<string, IGun>();
        }

        //------------ Properties -------------
        public IReadOnlyCollection<IGun> Models => this.guns.Values.ToList().AsReadOnly();

        //-------------- Methods --------------
        public void Add(IGun model)
        {
            if (!guns.ContainsKey(model.Name))
            {
                this.guns.Add(model.Name, model);
            }
        }

        public IGun Find(string name)
        {
            if (guns.ContainsKey(name))
            {
                return guns[name];
            }

            return null;
        }

        public bool Remove(IGun model)
        {
            if (guns.ContainsKey(model.Name))
            {
                return guns.Remove(model.Name);
            }

            return false;
        }
    }
}
