namespace ViceCity.Models.Players
{
    using ViceCity.Models.Players.Contracts;

    public class MainPlayer : Player, IPlayer
    {
        //------------ Constants --------------
        private const string InitialName = "Tommy Vercetti";
        private const int InitialLifePoints = 100;

        //----------- Constructors ------------
        public MainPlayer() : base(InitialName, InitialLifePoints)
        {

        }
    }
}
