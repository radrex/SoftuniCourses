namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        //---------------------- Methods ------------------------
        public string Read(string args)
        {
            string[] commandArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = (commandArgs[0] + "Command").ToLower();

            Type commandType = Assembly.GetCallingAssembly()
                                       .GetTypes()
                                       .FirstOrDefault(n => n.Name.ToLower() == commandName);
            // Use GetCallingAssembly for judge, don't use GetExecutingAssembly

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command.");
            }

            ICommand instance = Activator.CreateInstance(commandType) as ICommand;
            if (instance == null)
            {
                throw new ArgumentException("Invalid command.");
            }

            string result = instance.Execute(commandArgs);
            return result;
        }
    }
}
