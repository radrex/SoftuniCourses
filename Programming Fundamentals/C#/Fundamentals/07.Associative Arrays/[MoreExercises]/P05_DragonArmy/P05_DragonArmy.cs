namespace P05_DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P05_DragonArmy
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<int>>> dragons = new Dictionary<string, Dictionary<string, List<int>>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string type = data[0];
                string name = data[1];

                List<int> stats = new List<int> { 45, 250, 10 };
                for (int k = 2; k < 5; k++)
                {
                    if (data[k] != "null")
                    {
                        stats[k - 2] = int.Parse(data[k]);
                    }
                }

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new Dictionary<string, List<int>>() { { name, stats } });
                }
                else
                {
                    if (!dragons[type].ContainsKey(name))
                    {
                        dragons[type].Add(name, stats);
                    }
                    else
                    {
                        dragons[type][name] = stats;
                    }
                }
            }

            foreach (var type in dragons)
            {
                List<int> dmg = new List<int>();
                List<int> hp = new List<int>();
                List<int> armor = new List<int>();
                foreach (var stat in type.Value)
                {
                    dmg.Add(stat.Value[0]);
                    hp.Add(stat.Value[1]);
                    armor.Add(stat.Value[2]);
                }

                Console.WriteLine($"{type.Key}::({dmg.Average():F2}/{hp.Average():F2}/{armor.Average():F2})");
                foreach (var dragon in type.Value.OrderBy(d => d.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}