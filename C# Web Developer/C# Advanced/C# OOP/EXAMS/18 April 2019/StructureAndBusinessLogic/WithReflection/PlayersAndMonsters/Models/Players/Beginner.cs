namespace PlayersAndMonsters.Models.Players
{
    using Repositories.Contracts;

    public class Beginner : Player
    {
        private const int DefaultHealth = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, DefaultHealth)
        {
        }
    }
}
