namespace PlayersAndMonsters.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManagerController managerController;

        public CommandInterpreter(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Read(string[] inputArgs)
        {
            string commandName = inputArgs[0];
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            var method = typeof(ManagerController)
                .GetMethod(commandName);

            List<object> requiredParams = new List<object>();

            foreach (var commandArg in commandArgs)
            {
                if (int.TryParse(commandArg, out int parsedParam))
                {
                    requiredParams.Add(parsedParam);

                    continue;
                }

                requiredParams.Add(commandArg);
            }

            string result = (string)method.Invoke(this.managerController, requiredParams.ToArray());

            return result;
        }
    }
}
