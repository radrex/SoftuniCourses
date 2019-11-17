namespace P07_FoodShortage
{
    using P07_FoodShortage.Models;
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            City city = new City();

            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    city.AddCitizen(citizen);
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    Rebel rebel = new Rebel(name, age, group);
                    city.AddRebel(rebel);
                }

            }

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                if (city.Rebels.Any(r => r.Name == name))
                {
                    Rebel rebel = city.Rebels.First(r => r.Name == name);
                    rebel.BuyFood();
                }

                if (city.Citizens.Any(c => c.Name == name))
                {
                    Citizen citizen = city.Citizens.First(c => c.Name == name);
                    citizen.BuyFood();
                }
            }

            Console.WriteLine(city.Rebels.Sum(r => r.Food) + city.Citizens.Sum(c => c.Food));
        }
    }
}
