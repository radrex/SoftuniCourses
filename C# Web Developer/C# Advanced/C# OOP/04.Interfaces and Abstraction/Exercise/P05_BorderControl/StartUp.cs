namespace P05_BorderControl
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            City city = new City();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();
                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    Citizen citizen = new Citizen(name, age, id);
                    city.AddCitizen(citizen);
                }
                else if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    Robot robot = new Robot(model, id);
                    city.AddRobot(robot);
                }
            }

            string filter = Console.ReadLine();
            city.DetainRebels(filter);
            Console.WriteLine(city.ToString());
        }
    }
}
