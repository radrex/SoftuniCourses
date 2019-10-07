namespace P04_CitiesByContinentAndCountry
{
    using System;
    using System.Collections.Generic;

    class P04_CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> locations = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] tokens = Console.ReadLine().Split();
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!locations.ContainsKey(continent))
                {
                    locations.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!locations[continent].ContainsKey(country))
                {
                    locations[continent].Add(country, new List<string>());
                }

                locations[continent][country].Add(city);
            }

            foreach (var continent in locations)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {String.Join(", ", country.Value)}");
                }
            }
        }
    }
}
