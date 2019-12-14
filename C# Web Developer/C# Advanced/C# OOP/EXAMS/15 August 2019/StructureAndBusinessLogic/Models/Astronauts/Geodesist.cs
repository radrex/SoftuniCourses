namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public class Geodesist : Astronaut, IAstronaut
    {
        //------------- Constants --------------
        private const double InitialOxygen = 50;

        //----------- Constructors -------------
        public Geodesist(string name) 
            : base(name, InitialOxygen)
        {

        }
    }
}
