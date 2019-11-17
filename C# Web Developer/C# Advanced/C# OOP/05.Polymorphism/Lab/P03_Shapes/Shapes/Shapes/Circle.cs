namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        //-------------- Fields ----------------
        private double radius;

        //----------- Constructors -------------
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        //------------ Properties --------------
        public double Radius
        {
            get { return this.radius; }
            private set { this.radius = value; }
        }

        //------------- Methods ----------------
        public override double CalculateArea() => Math.PI * Math.Pow(this.Radius, 2);

        public override double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
