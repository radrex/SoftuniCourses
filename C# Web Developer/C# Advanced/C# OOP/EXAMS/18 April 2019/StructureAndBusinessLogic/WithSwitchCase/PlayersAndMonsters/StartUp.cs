namespace PlayersAndMonsters
{
    using PlayersAndMonsters.Core;
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();
            IWriter writer = new FileWriter();


            ICardRepository cardRepository = new CardRepository();
            ICardFactory cardFactory = new CardFactory();
            IPlayerRepository playerRepository = new PlayerRepository();
            IPlayerFactory playerFactory = new PlayerFactory();
            IBattleField battleField = new BattleField();

            IManagerController managerController = new ManagerController(cardRepository, cardFactory, playerRepository, playerFactory, battleField);

            IEngine engine = new Engine(reader, writer, managerController);
            engine.Run();
        }
    }
}