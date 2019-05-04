namespace P01_ExcellentResult
{
    using System;

    class P01_ExcellentResult
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }          
        }
    }
}
