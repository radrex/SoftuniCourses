namespace Shapes
{
    using System;

    public abstract class Shape
    {
        //------------ Methods ---------------
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();

        public virtual string Draw()
        {
            return "Drawing ";
        }
    }
}
