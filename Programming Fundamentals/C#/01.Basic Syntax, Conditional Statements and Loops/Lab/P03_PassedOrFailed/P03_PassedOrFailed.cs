namespace P03_PassedOrFailed
{
    using System;

    class P03_PassedOrFailed
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            Console.WriteLine(grade >= 3.00 ? "Passed!" : "Failed!");
        }
    }
}