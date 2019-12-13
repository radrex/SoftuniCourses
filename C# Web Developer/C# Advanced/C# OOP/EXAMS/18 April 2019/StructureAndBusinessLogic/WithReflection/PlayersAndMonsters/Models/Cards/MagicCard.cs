namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int DefaultDamagePoints = 5;
        private const int DefaultHealthPoints = 80;

        public MagicCard(string name) 
            : base(name, DefaultDamagePoints, DefaultHealthPoints)
        {
        }
    }
}
