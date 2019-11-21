namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        //---------------------- Fields ------------------------
        private readonly ICommandInterpreter commandInterpreter;

        //-------------------- Constructors --------------------
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;       
        }

        //---------------------- Methods -----------------------
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(this.commandInterpreter.Read(input));
            }
        }
    }
}
