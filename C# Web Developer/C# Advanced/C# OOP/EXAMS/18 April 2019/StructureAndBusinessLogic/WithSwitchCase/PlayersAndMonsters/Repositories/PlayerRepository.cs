namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        //-------------- Fields ---------------
        private Dictionary<string, IPlayer> players;

        //----------- Constructors ------------
        public PlayerRepository()
        {
            this.players = new Dictionary<string, IPlayer>();
        }

        //------------ Properties -------------
        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.Values.ToList().AsReadOnly();

        //------------- Methods ---------------
        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (this.players.ContainsKey(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player.Username, player);
        }

        public IPlayer Find(string username)
        {
            if (this.players.ContainsKey(username))
            {
                return this.players[username];
            }

            return null;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            return this.players.Remove(player.Username);
        }
    }
}
