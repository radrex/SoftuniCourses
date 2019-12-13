namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class TrapCard : Card, ICard
    {
        //------------ Constants --------------
        private const int InitialDamagePoints = 120;
        private const int InitialHealthPoints = 5;

        //----------- Constructors ------------
        public TrapCard(string name)
            : base(name, InitialDamagePoints, InitialHealthPoints)
        {

        }
    }
}
