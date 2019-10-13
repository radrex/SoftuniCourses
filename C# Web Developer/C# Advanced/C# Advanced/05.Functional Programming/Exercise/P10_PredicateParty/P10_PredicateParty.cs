namespace P10_PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P10_PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Party!")
                {
                    Console.WriteLine(people.Count != 0 ? $"{String.Join(", ", people)} are going to the party!" : "Nobody is going to the party!");
                    break;
                }

                string[] tokens = command.Split();
                command = tokens[0];
                string criteria = tokens[1];
                Predicate<string> filter;

                switch (command)
                {
                    case "Remove":
                        filter = CreateFilter(tokens, criteria);
                        people.RemoveAll(filter);
                        break;

                    case "Double":
                        filter = CreateFilter(tokens, criteria);
                        people.AddRange(people.Select(x => x).Where(x => filter(x)).ToArray());
                        break;

                    default:
                        break;
                }
            }
        }

        public static Predicate<string> CreateFilter(string[] tokens, string criteria)
        {
            Predicate<string> filter;
            switch (criteria)
            {
                case "StartsWith":      filter = x => x.StartsWith(tokens[2]);      break;
                case "EndsWith":        filter = x => x.EndsWith(tokens[2]);        break;

                case "Length":          int length = int.Parse(tokens[2]);
                                        filter = x => x.Length == length;           break;

                default:                filter = null;                              break;
            }

            return filter;
        }
    }
}
