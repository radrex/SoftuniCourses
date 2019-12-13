namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        //-------------- Fields ---------------
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        //----------- Constructors ------------
        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        //-------------- Methods --------------
        public void Run()
        {
            while (true)
            {
                string line = this.reader.ReadLine();

                if (line == "Exit")
                {
                    break;
                }

                string[] tokens = line.Split();
                string command = tokens[0];

                string output = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            string playerType = tokens[1];
                            string username = tokens[2];
                            output = this.managerController.AddPlayer(playerType, username);
                            break;

                        case "AddCard":
                            string cardType = tokens[1];
                            string cardName = tokens[2];
                            output = this.managerController.AddCard(cardType, cardName);
                            break;

                        case "AddPlayerCard":
                            username = tokens[1];
                            cardName = tokens[2];
                            output = this.managerController.AddPlayerCard(username, cardName);
                            break;

                        case "Fight":
                            string attackPlayer = tokens[1];
                            string enemyPlayer = tokens[2];
                            output = this.managerController.Fight(attackPlayer, enemyPlayer);
                            break;

                        case "Report":
                            output = this.managerController.Report();
                            break;

                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }

                if (!String.IsNullOrEmpty(output))
                {
                    this.writer.WriteLine(output);
                }
            }
        }
    }
}
