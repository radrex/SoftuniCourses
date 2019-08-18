namespace P03_HouseParty
{
    using System;
    using System.Collections.Generic;

    class P03_HouseParty
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] message = Console.ReadLine().Split();
                string name = message[0];

                if (message[2] == "not")
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else
                {
                    if (!guests.Contains(name))
                    {
                        guests.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, guests));
        }
    }
}