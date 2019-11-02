namespace P02_PointInRectangle
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] rectangleCoordinates = Console.ReadLine()
                                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray();
            int x1 = rectangleCoordinates[0];
            int y1 = rectangleCoordinates[1];
            int x2 = rectangleCoordinates[2];
            int y2 = rectangleCoordinates[3];
            Rectangle rectangle = new Rectangle(x1, y1, x2, y2);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
                Point point = new Point(tokens[0], tokens[1]);
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
