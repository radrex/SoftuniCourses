namespace CommandPattern.Core.Commands
{
    using CommandPattern.Core.Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        //---------------------- Methods ------------------------
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
