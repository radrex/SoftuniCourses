namespace Shapes
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(2, 3);
            Shape circle = new Circle(2.5);

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
        }
    }
}
