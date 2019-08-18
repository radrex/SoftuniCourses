namespace P03_LongerLine
{
    using System;

    class P03_LongerLine
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintLongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        public static void PrintLongerLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double firstLineLen = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double secondLineLen = Math.Sqrt(Math.Pow((x4 - x3), 2) + Math.Pow((y4 - y3), 2));

            if (firstLineLen >= secondLineLen)
            {
                bool isFirstPointCloser = ClosestPoint(x1, y1, x2, y2);
                Console.WriteLine(isFirstPointCloser ? $"({x1}, {y1})({x2}, {y2})" : $"({x2}, {y2})({x1}, {y1})");
            }
            else
            {
                bool isFirstCloser = ClosestPoint(x3, y3, x4, y4);
                Console.WriteLine(isFirstCloser ? $"({x3}, {y3})({x4}, {y4})" : $"({x4}, {y4})({x3}, {y3})");
            }
        }

        public static bool ClosestPoint(double x1, double y1, double x2, double y2)
        {
            double x = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            double y = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));
            bool isFirstPointCloser = true;

            isFirstPointCloser = (x <= y) ? true : false;
            return isFirstPointCloser;
        }
    }
}