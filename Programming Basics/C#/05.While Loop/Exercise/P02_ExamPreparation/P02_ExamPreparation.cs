namespace P02_ExamPreparation
{
    using System;

    class P02_ExamPreparation
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());
            string lastTask = string.Empty;
            double summedGrades = 0.0;
            int problems = 0;
            int poorGrades = 0;

            while (badGrades > 0)
            {
                string currentTask = Console.ReadLine();
                if (currentTask == "Enough")
                {
                    Console.WriteLine($"Average score: {summedGrades / problems:F2}");
                    Console.WriteLine($"Number of problems: {problems}");
                    Console.WriteLine($"Last problem: {lastTask}");
                    return;
                }

                lastTask = currentTask;
                int grade = int.Parse(Console.ReadLine());
                summedGrades += grade;
                problems++;

                if (grade <= 4.0)
                {
                    badGrades--;
                    poorGrades++;
                }
            }

            Console.WriteLine($"You need a break, {poorGrades} poor grades.");
        }
    }
}
