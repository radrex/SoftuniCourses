namespace P06_BirthdayCelebrations
{
    using P06_BirthdayCelebrations.Models;
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
                if (tokens.Length == 5)
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    city.AddCitizen(citizen);
                }
                else if (tokens.Length == 3)
                {
                    switch (tokens[0])
                    {
                        case "Pet":
                            string name = tokens[1];
                            string birthdate = tokens[2];
                            Pet pet = new Pet(name, birthdate);
                            city.AddPet(pet);
                            break;

                        case "Robot":
                            string model = tokens[1];
                            string id = tokens[2];
                            Robot robot = new Robot(model, id);
                            city.AddRobot(robot);
                            break;

                        default:
                            break;
                    }
                }
            }

            string year = Console.ReadLine();
            city.PrintBirthdates(year);
        }
    }
}
