namespace P08_GraduationPt2
{
    using System;

    class P08_GraduationPt2
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 1;
            double sum = 0.0;

            int excluded = 0;
            bool isExcluded = false;

            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4.00)
                {
                    excluded++;
                }
                else if (grade >= 4.00)
                {
                    sum += grade;
                    counter++;
                }

                if (excluded >= 2)
                {
                    isExcluded = true;
                    break;
                }
            }

            if (!isExcluded)
            {
                double average = sum / 12.0;
                Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {counter} grade");
            }
        }
    }
}
