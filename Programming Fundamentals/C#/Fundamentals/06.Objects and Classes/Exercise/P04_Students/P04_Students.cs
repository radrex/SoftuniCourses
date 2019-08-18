namespace P04_Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P04_Students
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] studentData = Console.ReadLine().Split();
                Student student = new Student()
                {
                    FirstName = studentData[0],
                    LastName = studentData[1],
                    Grade = double.Parse(studentData[2])
                };

                students.Add(student);
            }

            students.OrderByDescending(s => s.Grade).ToList().ForEach(s => Console.WriteLine(s));
        }
    }

    class Student
    {
        public Student()
        {

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:F2}";
        }
    }
}