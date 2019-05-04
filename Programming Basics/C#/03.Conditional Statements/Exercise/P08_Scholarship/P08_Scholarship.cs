namespace P08_Scholarship
{
    using System;

    class P08_Scholarship
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());

            double socialScholarship = 0.0;
            bool isSocialScholarshipGranted = false;

            double gradeScholarship = 0.0;
            bool isGradeScholarshipGranted = false;


            if (income < minimalSalary && averageGrade > 4.5)
            {
                socialScholarship = minimalSalary * 0.35;
                isSocialScholarshipGranted = true;
            }

            if (averageGrade >= 5.5)
            {
                gradeScholarship = averageGrade * 25;
                isGradeScholarshipGranted = true;
            }

            if (!isSocialScholarshipGranted && !isGradeScholarshipGranted)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (isSocialScholarshipGranted && !isGradeScholarshipGranted)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
            else if (!isSocialScholarshipGranted && isGradeScholarshipGranted)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(gradeScholarship)} BGN");
            }
            else
            {
                if (socialScholarship > gradeScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
                else if (socialScholarship < gradeScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(gradeScholarship)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(gradeScholarship)} BGN");
                }
            }
        }
    }
}
