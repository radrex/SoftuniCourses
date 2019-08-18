namespace P06_Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P06_Courses
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string[] command = Console.ReadLine().Split(" : ");

            while (command[0] != "end")
            {
                string course = command[0];
                string student = command[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }

                if (!courses[course].Contains(student))
                {
                    courses[course].Add(student);
                }

                command = Console.ReadLine().Split(" : ");
            }

            foreach (var course in courses.OrderByDescending(c => c.Value.Count()))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count()}");
                foreach (string user in course.Value.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }
    }
}