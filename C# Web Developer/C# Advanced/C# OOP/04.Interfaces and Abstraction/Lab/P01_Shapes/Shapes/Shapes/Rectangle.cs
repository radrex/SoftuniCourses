namespace Shapes
{
    using System;

    public class Rectangle : IDrawable
    {
        //------------Fields---------------
        private int width;
        private int height;

        //---------Constructors------------
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        //----------Properties-------------
        public int Width
        {
            get { return this.width; }
            private set { this.width = value; }
        }
        public int Height
        {
            get { return this.height; }
            private set { this.height = value; }
        }
        //------------Methods--------------
        public void Draw()
        {
            Console.WriteLine(new String('*', this.Width));
            for (int i = 0; i < this.Height - 2; i++)
            {
                Console.WriteLine($"*{new String(' ', this.Width - 2)}*");
            }
            Console.WriteLine(new String('*', this.Width));
        }
    }
}
