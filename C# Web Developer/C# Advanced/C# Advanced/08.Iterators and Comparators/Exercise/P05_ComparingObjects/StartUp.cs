namespace P05_ComparingObjects
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split();
                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person selectedPerson = people[index];

            int equal = 0;
            int notEqual = 0;

            foreach (Person person in people)
            {
                if (person.CompareTo(selectedPerson) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (equal > 1)
            {
                Console.WriteLine($"{equal} {notEqual} {equal + notEqual}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
