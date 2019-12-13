namespace PlayersAndMonsters.Core
{
    using System.Text;

    using Contracts;
    using Common;
    using Core.Factories.Contracts;
    using Models.BattleFields.Contracts;
    using Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly ICardRepository cardRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly IBattleField battleField;
        private readonly ICardFactory cardFactory;
        private readonly IPlayerFactory playerFactory;

        public ManagerController(
            ICardRepository cardRepository,
            IPlayerRepository playerRepository,
            IBattleField battleField,
            ICardFactory cardFactory,
            IPlayerFactory playerFactory)
        {
            this.cardRepository = cardRepository;
            this.battleField = battleField;
            this.playerRepository = playerRepository;
            this.cardFactory = cardFactory;
            this.playerFactory = playerFactory;
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, player.GetType().Name,
                player.Username);

            return result;
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedCard, card.GetType().Name, card.Name);

            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            var result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, card.Name,
                player.Username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRepository.Find(attackUser);
            var enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            string result = string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);

            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            var players = this.playerRepository.Players;

            foreach (var player in players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
