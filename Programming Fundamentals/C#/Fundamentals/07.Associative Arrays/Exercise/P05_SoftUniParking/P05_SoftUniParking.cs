namespace P05_SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P05_SoftUniParking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingLot = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string user = command[1];

                switch (command[0])
                {
                    case "register":
                        string licensePlate = command[2];
                        if (!parkingLot.ContainsKey(user))
                        {
                            parkingLot.Add(user, licensePlate);
                            Console.WriteLine($"{user} registered {licensePlate} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                        }
                        break;

                    case "unregister":
                        if (!parkingLot.ContainsKey(user))
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                        }
                        else
                        {
                            parkingLot.Remove(user);
                            Console.WriteLine($"{user} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (var user in parkingLot)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}