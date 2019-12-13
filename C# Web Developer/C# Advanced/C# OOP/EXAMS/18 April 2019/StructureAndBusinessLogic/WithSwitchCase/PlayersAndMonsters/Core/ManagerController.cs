namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        //-------------- Fields ---------------
        private ICardRepository cardRepository;
        private ICardFactory cardFactory;

        private IPlayerRepository playerRepository;
        private IPlayerFactory playerFactory;

        private IBattleField battleField;

        //----------- Constructors ------------
        public ManagerController(ICardRepository cardRepository, ICardFactory cardFactory, 
                                 IPlayerRepository playerRepository, IPlayerFactory playerFactory,
                                 IBattleField battleField)
        {
            this.cardRepository = cardRepository;
            this.cardFactory = cardFactory;

            this.playerRepository = playerRepository;
            this.playerFactory = playerFactory;

            this.battleField = battleField;
        }

        //------------- Methods ---------------
        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            ICard card = this.cardRepository.Find(cardName);
            IPlayer player = this.playerRepository.Find(username);
            player.CardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return String.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IPlayer player in this.playerRepository.Players)
            {
                sb.AppendLine(String.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));
                foreach (ICard card in player.CardRepository.Cards)
                {
                    sb.AppendLine(String.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }
                sb.AppendLine(String.Format(ConstantMessages.DefaultReportSeparator));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
