namespace P04a_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departmentName = tokens[0];
                var doctorFullName = tokens[1] + tokens[2];
                var patientName = tokens[3];

                if (!doctors.ContainsKey(doctorFullName))
                {
                    doctors[doctorFullName] = new List<string>();
                }
                if (!departments.ContainsKey(departmentName))
                {
                    departments[departmentName] = new List<List<string>>();
                    for (int stai = 0; stai < 20; stai++)
                    {
                        departments[departmentName].Add(new List<string>());
                    }
                }

                bool isEmpty = departments[departmentName].SelectMany(x => x).Count() < 60;
                if (isEmpty)
                {
                    int room = 0;
                    doctors[doctorFullName].Add(patientName);
                    for (int roomNumber = 0; roomNumber < departments[departmentName].Count; roomNumber++)
                    {
                        if (departments[departmentName][roomNumber].Count < 3)
                        {
                            room = roomNumber;
                            break;
                        }
                    }
                    departments[departmentName][room].Add(patientName);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] arguments = command.Split();

                if (arguments.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[arguments[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (arguments.Length == 2 && int.TryParse(arguments[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[arguments[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[arguments[0] + arguments[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
