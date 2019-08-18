namespace P07_OrderByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P07_OrderByAge
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string[] personData = Console.ReadLine().Split();
            while (personData[0] != "End")
            {
                string name = personData[0];
                string ID = personData[1];
                int age = int.Parse(personData[2]);

                Person person = new Person()
                {
                    Name = name,
                    ID = ID,
                    Age = age
                };
                people.Add(person);

                personData = Console.ReadLine().Split();
            }

            people.OrderBy(p => p.Age)
                  .ToList()
                  .ForEach(p => Console.WriteLine(p));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}