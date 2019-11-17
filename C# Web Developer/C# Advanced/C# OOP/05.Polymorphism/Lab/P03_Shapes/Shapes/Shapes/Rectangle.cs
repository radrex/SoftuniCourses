namespace Shapes
{
    public class Rectangle : Shape
    {
        //-------------- Fields ----------------
        private double height;
        private double width;

        //----------- Constructors -------------
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        //------------ Properties --------------
        public double Height
        {
            get { return this.height; }
            private set { this.height = value; }
        }
        public double Width
        {
            get { return this.width; }
            private set { this.width = value; }
        }

        //------------- Methods ----------------
        public override double CalculateArea() => this.Width * this.Height;

        public override double CalculatePerimeter() => this.Width * 2 + this.Height * 2;

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
