namespace P02_PointInRectangle
{
    public class Rectangle
    {
        //------Constructors------
        public Rectangle()
        {
            this.Points = new Point[2];
        }
        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            this.Points = new Point[] { new Point(topLeftX, topLeftY), new Point(bottomRightX, bottomRightY) };
        }

        //-------Properties-------
        public Point[] Points { get; set; }

        //--------Methods---------
        public bool Contains(Point point)
        {
            bool isInHorizontal = this.Points[0].X <= point.X && this.Points[1].X >= point.X;
            bool isInVertical = this.Points[0].Y <= point.Y && this.Points[1].Y >= point.Y;

            bool isInRectangle = isInHorizontal && isInVertical;
            return isInRectangle;
        }
    }
}
