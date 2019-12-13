namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models.Cards.Contracts;
    using Contracts;

    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count
            => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards
            => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException($"Card cannot be null!");
            }

            var cardExists = this.cards
                .Any(x => x.Name == card.Name);

            if (cardExists)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException($"Card cannot be null!");
            }

            var isRemove = this.cards.Remove(card);

            return isRemove;
        }

        public ICard Find(string name)
        {
            return this.cards
                .FirstOrDefault(x => x.Name == name);
        }
    }
}
