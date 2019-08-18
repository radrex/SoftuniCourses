namespace P10_SoftUniCoursePlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P10_SoftUniCoursePlanning
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine()
                                          .Split(", ")
                                          .ToList();

            string[] command = Console.ReadLine().Split(':');
            while (command[0] != "course start")
            {
                switch (command[0])
                {
                    case "Add":
                        if (!courses.Contains(command[1]))
                        {
                            courses.Add(command[1]);
                        }
                        break;

                    case "Insert":
                        if (!courses.Contains(command[1]))
                        {
                            courses.Insert(int.Parse(command[2]), command[1]);
                        }
                        break;

                    case "Remove":
                        if (courses.Contains(command[1]))
                        {
                            courses.Remove(command[1]);
                            if (courses.Contains($"{command[1]}-Exercise"))
                            {
                                courses.Remove($"{command[1]}-Exercise");
                            }
                        }
                        break;

                    case "Swap":
                        if (courses.Contains(command[1]) && courses.Contains(command[2]))
                        {
                            int c1 = courses.FindIndex(c => c == command[1]);
                            int c2 = courses.FindIndex(c => c == command[2]);
                            courses[c1] = command[2];
                            courses[c2] = command[1];

                            if (courses.Contains($"{command[1]}-Exercise"))
                            {
                                courses.Remove($"{command[1]}-Exercise");
                                courses.Insert(c2 + 1, $"{command[1]}-Exercise");
                            }

                            if (courses.Contains($"{command[2]}-Exercise"))
                            {
                                courses.Remove($"{command[2]}-Exercise");
                                courses.Insert(c1 + 1, $"{command[2]}-Exercise");
                            }
                        }
                        break;

                    case "Exercise":
                        if (!courses.Contains(command[1]))
                        {
                            courses.Add(command[1]);
                            courses.Add($"{command[1]}-Exercise");
                        }
                        else
                        {
                            if (!courses.Contains($"{command[1]}-Exercise"))
                            {
                                int c = courses.FindIndex(ci => ci == command[1]);
                                courses.Insert(c + 1, $"{command[1]}-Exercise");
                            }
                        }
                        break;
                }

                command = Console.ReadLine().Split(':');
            }

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }
        }
    }
}