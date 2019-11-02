namespace P03_StudentSystem
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystem studentSystem = new StudentSystem();
            while (true)
            {
                string input = Console.ReadLine();
                studentSystem.ParseCommand(input);
            }
        }
    }
}
