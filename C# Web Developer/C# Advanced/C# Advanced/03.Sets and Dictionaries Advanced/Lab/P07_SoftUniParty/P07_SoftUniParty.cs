namespace P07_SoftUniParty
{
    using System;
    using System.Collections.Generic;

    class P07_SoftUniParty
    {
        static void Main(string[] args)
        {
            HashSet<string> vips = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "PARTY")
            {
                if (Char.IsDigit(command[0]))
                {
                    vips.Add(command);
                }
                else
                {
                    guests.Add(command);
                }
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "END")
            {
                if (Char.IsDigit(command[0]))
                {
                    vips.Remove(command);
                }
                else
                {
                    guests.Remove(command);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(guests.Count + vips.Count);
            foreach (var item in vips)
            {
                Console.WriteLine(item);
            }
            foreach (var item in guests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
