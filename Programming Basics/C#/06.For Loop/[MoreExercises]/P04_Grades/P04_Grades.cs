namespace P04_Grades
{
    using System;

    class P04_Grades
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int A = 0;
            int B = 0;
            int C = 0;
            int F = 0;
            double gradesSummed = 0.0;

            for (int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                gradesSummed += grade;
                if (grade < 3.00)
                {
                    F++;
                }
                else if (grade >= 3.00 && grade <= 3.99)
                {
                    C++;
                }
                else if (grade >= 4.00 && grade <= 4.99)
                {
                    B++;
                }
                else
                {
                    A++;
                }
            }

            Console.WriteLine($"Top students: {((double)A / students) * 100:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {((double)B / students) * 100:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {((double)C / students) * 100:F2}%");
            Console.WriteLine($"Fail: {((double)F / students) * 100:F2}%");
            Console.WriteLine($"Average: {gradesSummed / students:F2}");
        }
    }
}
