namespace P06_CalculateRectangleArea
{
    using System;

    class P06_CalculateRectangleArea
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = GetRectangleArea(width, height);
            Console.WriteLine(area);
        }

        public static double GetRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}