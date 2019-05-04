namespace P07_TrainTheTrainers
{
    using System;

    class P07_TrainTheTrainers
    {
        static void Main(string[] args)
        {
            int juryCount = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();

            double finalAssessment = 0.0;
            int presentationsCount = 0;

            while (presentationName != "Finish")
            {
                double sumGrades = 0.0;
                for (int i = 1; i <= juryCount; i++)
                {
                    sumGrades += double.Parse(Console.ReadLine());
                }

                double averageGrade = sumGrades /= juryCount;
                finalAssessment += sumGrades;
                Console.WriteLine($"{presentationName} - {averageGrade:F2}.");
                presentationsCount++;
                presentationName = Console.ReadLine();
            }

            finalAssessment /= presentationsCount;
            Console.WriteLine($"Student's final assessment is {finalAssessment:F2}.");
        }
    }
}
