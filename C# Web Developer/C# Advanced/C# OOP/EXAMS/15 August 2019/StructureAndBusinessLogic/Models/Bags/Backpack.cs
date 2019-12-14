using System.Collections.Generic;
namespace SpaceStation.Models.Bags
{
    using System.Linq;

    public class Backpack : IBag
    {
        //------------- Fields --------------
        private ICollection<string> items;


        //---------- Constructors -----------
        public Backpack()
        {
            this.items = new List<string>();
        }

        //----------- Properties ------------
        public ICollection<string> Items => this.items;
    }
}
