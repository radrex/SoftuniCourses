namespace P02_AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P02_AverageStudentGrades
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                double grade = double.Parse(data[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }
                else
                {
                    students[name].Add(grade);
                }
            }

            foreach (var student in students)
            {
                string text = student.Key + " -> ";
                foreach (double grade in student.Value)
                {
                    text += $"{grade:F2} ";
                }
                Console.WriteLine(text + $"(avg: {student.Value.Average():F2})");
            }
        }
    }
}
