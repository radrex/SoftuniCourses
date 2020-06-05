namespace P02_OldestFamilyMember
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_OldestFamilyMember
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split();
                Person person = new Person()
                {
                    Name = personData[0],
                    Age = int.Parse(personData[1])
                };
                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }

    class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(p => p.Age).First();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}