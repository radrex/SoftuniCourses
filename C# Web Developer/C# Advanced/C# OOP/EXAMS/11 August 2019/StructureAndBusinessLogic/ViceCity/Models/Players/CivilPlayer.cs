namespace ViceCity.Models.Players
{
    using ViceCity.Models.Players.Contracts;

    public class CivilPlayer : Player, IPlayer
    {
        //------------ Constants --------------
        private const int InitialLifePoints = 50;

        //----------- Constructors ------------
        public CivilPlayer(string name) 
            : base(name, InitialLifePoints)
        {

        }
    }
}
