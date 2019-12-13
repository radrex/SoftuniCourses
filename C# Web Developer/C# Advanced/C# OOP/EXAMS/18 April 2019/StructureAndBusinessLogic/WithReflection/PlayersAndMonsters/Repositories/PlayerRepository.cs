namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Players.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count
            => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players
            => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException($"Player cannot be null!");
            }

            var playerExists = this.players
                .Any(x => x.Username == player.Username);

            if (playerExists)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException($"Player cannot be null!");
            }

            var isRemove = this.players.Remove(player);

            return isRemove;
        }

        public IPlayer Find(string username)
        {
            return this.players
                .FirstOrDefault(x => x.Username == username);
        }
    }
}
