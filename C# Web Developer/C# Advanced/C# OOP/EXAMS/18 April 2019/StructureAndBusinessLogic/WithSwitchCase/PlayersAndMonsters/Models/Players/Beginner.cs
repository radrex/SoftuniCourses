namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class Beginner : Player, IPlayer
    {
        //------------ Constants --------------
        private const int InitialHealthPoints = 50;

        //----------- Constructors ------------
        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, InitialHealthPoints)
        {

        }
    }
}
