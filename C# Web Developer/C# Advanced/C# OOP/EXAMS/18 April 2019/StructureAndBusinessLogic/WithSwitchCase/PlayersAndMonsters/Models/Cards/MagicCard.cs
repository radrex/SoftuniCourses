namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class MagicCard : Card, ICard
    {
        //------------ Constants --------------
        private const int InitialDamagePoints = 5;
        private const int InitialHealthPoints = 80;

        //----------- Constructors ------------
        public MagicCard(string name) 
            : base(name, InitialDamagePoints, InitialHealthPoints)
        {

        }
    }
}
