namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class CardRepository : ICardRepository
    {
        //-------------- Fields ---------------
        private Dictionary<string, ICard> cards;

        //----------- Constructors ------------
        public CardRepository()
        {
            this.cards = new Dictionary<string, ICard>();
        }

        //------------ Properties -------------
        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.Values.ToList().AsReadOnly();

        //------------- Methods ---------------
        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (this.cards.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            if (this.cards.ContainsKey(name))
            {
                return this.cards[name];
            }

            return null;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            return this.cards.Remove(card.Name);
        }
    }
}
