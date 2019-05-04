namespace P02_TriangleArea
{
    using System;

    class P02_TriangleArea
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double triangleArea = side * h / 2.0;

            Console.WriteLine($"{triangleArea:F2}");
        }
    }
}
