namespace P08_MilitaryElite.Core
{
    using System;

    public class Engine : IEngine
    {
        //-------------------- Fields ----------------------
        private readonly ICommandInterpreter commandInterpreter;

        //----------------- Constructors -------------------
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        //------------------- Methods ----------------------
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] commands = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string result = this.commandInterpreter.Read(commands);
                    Console.WriteLine(result);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
