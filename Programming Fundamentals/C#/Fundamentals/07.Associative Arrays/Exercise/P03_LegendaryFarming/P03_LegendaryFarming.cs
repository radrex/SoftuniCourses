namespace P03_LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P03_LegendaryFarming
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> junks = new Dictionary<string, int>();
            Dictionary<string, int> materials = new Dictionary<string, int>()
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };

            bool isItemObtainable = false;
            while (!isItemObtainable)
            {
                string[] input = Console.ReadLine().Split();
                int quantity = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (i % 2 != 0)  // Material or Junk
                    {
                        string resource = input[i].ToLower();
                        if (materials.ContainsKey(resource))    // Material
                        {
                            materials[resource] += quantity;
                            if (materials[resource] >= 250)
                            {
                                isItemObtainable = true;
                                break;
                            }
                        }
                        else  // Junk                               
                        {
                            if (!junks.ContainsKey(resource))
                            {
                                junks.Add(resource, 0);
                            }
                            junks[resource] += quantity;
                        }
                    }
                    else  // Quantity
                    {
                        quantity = int.Parse(input[i]);
                    }
                }
            }

            KeyValuePair<string, int> kvp = materials.FirstOrDefault(v => v.Value >= 250);
            materials[kvp.Key] -= 250;
            string item = string.Empty;

            switch (kvp.Key)
            {
                case "shards": item = "Shadowmourne"; break;
                case "fragments": item = "Valanyr"; break;
                case "motes": item = "Dragonwrath"; break;
            }

            Console.WriteLine($"{item} obtained!");
            foreach (var material in materials.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var junk in junks.OrderBy(j => j.Key))
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }
    }
}