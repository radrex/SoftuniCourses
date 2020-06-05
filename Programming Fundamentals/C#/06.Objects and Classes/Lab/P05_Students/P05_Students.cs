namespace P05_Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P05_Students
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                Student student = new Student()
                {
                    FirstName = command[0],
                    LastName = command[1],
                    Age = int.Parse(command[2]),
                    City = command[3]
                };

                students.Add(student);
                command = Console.ReadLine().Split();
            }

            string city = Console.ReadLine();
            students.Where(s => s.City == city)
                    .ToList()
                    .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} is {s.Age} years old."));
        }
    }

    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }
}
