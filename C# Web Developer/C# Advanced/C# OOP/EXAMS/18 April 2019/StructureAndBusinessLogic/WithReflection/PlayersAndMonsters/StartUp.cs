namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();

            IBattleField battleField = new BattleField();
            ICardRepository cardRepository = new CardRepository();
            IPlayerRepository playerRepository = new PlayerRepository();
            ICardFactory cardFactory = new CardFactory();
            IPlayerFactory playerFactory = new PlayerFactory();

            IManagerController managerController = new ManagerController(
                cardRepository,
                playerRepository,
                battleField,
                cardFactory,
                playerFactory
            );

            ICommandInterpreter commandInterpreter = new CommandInterpreter(managerController);
            IEngine engine = new Engine(commandInterpreter, reader, writer);
            engine.Run();
        }
    }
}