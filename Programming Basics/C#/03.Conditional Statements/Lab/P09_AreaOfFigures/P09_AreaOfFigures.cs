namespace P09_AreaOfFigures
{
    using System;

    class P09_AreaOfFigures
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine().ToLower();
            double area = 0.0;

            switch (figureType)
            {
                case "square":
                    double side = double.Parse(Console.ReadLine());
                    area = side * side;
                    break;

                case "rectangle":
                    double a = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    area = a * b;
                    break;

                case "circle":
                    double r = double.Parse(Console.ReadLine());
                    area = Math.PI * Math.Pow(r, 2);
                    break;

                case "triangle":
                    double baseSide = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    area = 1.0 / 2.0 * baseSide * height;
                    break;
            }

            Console.WriteLine($"{area:F3}");
        }
    }
}
