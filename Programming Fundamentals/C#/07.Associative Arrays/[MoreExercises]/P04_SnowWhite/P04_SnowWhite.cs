namespace P04_SnowWhite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P04_SnowWhite
    {
        static void Main(string[] args)
        {
            Dictionary<KeyValuePair<string, string>, int> dwarfs = new Dictionary<KeyValuePair<string, string>, int>();
            string[] command = Console.ReadLine().Split("<:>", StringSplitOptions.RemoveEmptyEntries)
                                                 .Select(x => x.Trim()).ToArray();
            while (command[0] != "Once upon a time")
            {
                string name = command[0];
                string hatColor = command[1];
                int physics = int.Parse(command[2]);
                KeyValuePair<string, string> key = new KeyValuePair<string, string>(hatColor, name);

                if (!dwarfs.ContainsKey(key))
                {
                    dwarfs.Add(key, physics);
                }
                else
                {
                    dwarfs[key] = Math.Max(dwarfs[key], physics);
                }

                command = Console.ReadLine().Split("<:>", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(d => d.Value).ThenByDescending(x => dwarfs.Where(y => y.Key.Key == x.Key.Key).Count()))
            {
                Console.WriteLine($"({dwarf.Key.Key}) {dwarf.Key.Value} <-> {dwarf.Value}");
            }
        }
    }
}