namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    using Models.Players.Contracts;
    using Repositories;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var playerType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (playerType == null)
            {
                throw new ArgumentException("Player of this type does not exists!");
            }

            var repository = new CardRepository();

            var player = (IPlayer)Activator.CreateInstance(playerType, repository, username);

            return player;
        }
    }
}
