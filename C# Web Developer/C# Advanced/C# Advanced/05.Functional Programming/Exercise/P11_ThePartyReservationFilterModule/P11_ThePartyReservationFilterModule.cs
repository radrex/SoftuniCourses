namespace P11_ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P11_ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> invitations = Console.ReadLine().Split().ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Print")
                {
                    break;
                }

                string[] tokens = command.Split(';');
                command = tokens[0];
                string criteria = tokens[1];
                string key = $"{tokens[1]} {tokens[2]}";

                switch (command)
                {
                    case "Add filter":
                        if (!filters.ContainsKey(key))
                        {
                            filters.Add(key, CreateFilter(tokens, criteria));
                        }
                        break;

                    case "Remove filter":
                        if (filters.ContainsKey(key))
                        {
                            filters.Remove(key);
                        }
                        break;

                    default:
                        break;
                }
            }

            foreach (var predicate in filters.Values)
            {
                invitations.RemoveAll(predicate);
            }

            Console.WriteLine(String.Join(" ", invitations));
        }

        public static Predicate<string> CreateFilter(string[] tokens, string criteria)
        {
            Predicate<string> filter;
            switch (criteria)
            {
                case "Starts with":      filter = x => x.StartsWith(tokens[2]);      break;
                case "Ends with":        filter = x => x.EndsWith(tokens[2]);        break;
                case "Contains":        filter = x => x.Contains(tokens[2]);        break;

                case "Length":
                                        int length = int.Parse(tokens[2]);
                                        filter = x => x.Length == length;           break;

                default:                filter = null;                              break;
            }

            return filter;
        }
    }
}
