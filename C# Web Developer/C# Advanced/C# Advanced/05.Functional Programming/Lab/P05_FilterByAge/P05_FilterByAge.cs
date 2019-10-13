namespace P05_FilterByAge
{
    using System;
    using System.Collections.Generic;

    class P05_FilterByAge
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] personData = Console.ReadLine().Split(", ");
                string name = personData[0];
                int ageData = int.Parse(personData[1]);

                if (!people.ContainsKey(name))
                {
                    people[name] = ageData;
                }
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);
            PrintFilteredStudent(people, tester, printer);
        }

        public static void PrintFilteredStudent(Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        public static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":     return x => x < age;
                case "older":       return x => x >= age;
                default:            return null;
            }
        }

        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":        return person => Console.WriteLine($"{person.Key}");
                case "age":         return person => Console.WriteLine($"{person.Value}");
                case "name age":    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default:            return null;
            }
        }
    }
}
