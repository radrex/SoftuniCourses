namespace P06_Wardrobe
{
    using System;
    using System.Collections.Generic;

    class P06_Wardrobe
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] tokens = Console.ReadLine().Split(" -> ");
                string color = tokens[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                string[] clothes = tokens[1].Split(',');
                foreach (string cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 1);
                    }
                    else
                    {
                        wardrobe[color][cloth]++;
                    }
                }
            }

            string[] desiredItem = Console.ReadLine().Split();
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    Console.WriteLine(desiredItem[0] == color.Key && desiredItem[1] == cloth.Key ? $"* {cloth.Key} - {cloth.Value} (found!)" : 
                                                                                                   $"* {cloth.Key} - {cloth.Value}");
                }
            }
        }
    }
}
