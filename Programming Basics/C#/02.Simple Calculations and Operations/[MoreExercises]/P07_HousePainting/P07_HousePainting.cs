namespace P07_HousePainting
{
    using System;

    class P07_HousePainting
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            //---------------------- GREEN PAINT ----------------------------
            double sideWallsArea = ((x * y) - (1.5 * 1.5)) * 2;
            double frontWallArea = (x * x) - (1.2 * 2);
            double backWallArea = x * x;

            double greenPaint = (sideWallsArea + (frontWallArea + backWallArea)) / 3.4;

            //----------------------- RED PAINT -----------------------------
            double rectanglesArea = 2 * (x * y);
            double trianglesArea = 2 * (x * h / 2);

            double redPaint = (rectanglesArea + trianglesArea) / 4.3;

            //---------------------------------------------------------------
            Console.WriteLine($"{greenPaint:F2}");
            Console.WriteLine($"{redPaint:F2}");
        }
    }
}
