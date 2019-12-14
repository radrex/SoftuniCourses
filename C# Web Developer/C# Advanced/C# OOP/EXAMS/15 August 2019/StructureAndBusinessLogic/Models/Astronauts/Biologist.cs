namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public class Biologist : Astronaut, IAstronaut
    {
        //------------- Constants --------------
        private const double InitialOxygen = 70;

        //----------- Constructors -------------
        public Biologist(string name) 
            : base(name, InitialOxygen)
        {

        }

        public override void Breath()
        {
            if (this.Oxygen >= 5)
            {
                this.Oxygen -= 5;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
