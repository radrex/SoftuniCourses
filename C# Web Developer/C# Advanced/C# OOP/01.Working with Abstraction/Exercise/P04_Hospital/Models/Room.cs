namespace P04_Hospital.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Room
    {
        //---------------- Fields --------------------
        private Bed[] beds;

        //-------------- Constructors ----------------
        public Room()
        {
            this.beds = new Bed[3];
            this.InitializeBeds();
        }

        //--------------- Properties -----------------
        public Bed[] Beds => this.beds;

        //------------- Private Methods --------------
        private void InitializeBeds()
        {
            for (int i = 0; i < this.beds.Length; i++)
            {
                this.beds[i] = new Bed();
            }
        }
    }
}
