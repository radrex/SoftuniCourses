namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class Advanced : Player, IPlayer
    {
        //------------ Constants --------------
        private const int InitialHealthPoints = 250;

        //----------- Constructors ------------
        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, InitialHealthPoints)
        {

        }
    }
}
