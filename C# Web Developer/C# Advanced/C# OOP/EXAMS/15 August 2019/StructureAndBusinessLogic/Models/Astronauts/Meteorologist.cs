namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public class Meteorologist : Astronaut, IAstronaut
    {
        //------------- Constants --------------
        private const double InitialOxygen = 90;

        //----------- Constructors -------------
        public Meteorologist(string name) 
            : base(name, InitialOxygen)
        {

        }
    }
}
