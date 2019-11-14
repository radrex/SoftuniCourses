namespace P01_ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        //--------------------- Fields -------------------------
        private double length;
        private double width;
        private double height;

        //------------------- Constructors ---------------------
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        //-------------------- Properties ----------------------
        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        //---------------------- Methods -----------------------
        public double SurfaceArea()
        {
            return 2.0 * this.Length * this.Width + 2.0 * this.Length * this.Height + 2.0 * this.Width * this.Height;
        }

        public double LateralSurfaceArea()
        {
            return 2.0 * this.Length * this.Height + 2.0 * this.Width * this.Height;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.Volume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
