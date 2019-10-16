namespace CarManufacturer
{
    class Engine
    {
        //----------------- Fields -----------------
        private int horsePower;
        private double cubicCapacity;

        //-------------- Constructors --------------
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        //--------------- Properties ---------------
        public int HorsePower
        {
            get { return this.horsePower; }
            private set { this.horsePower = value; }
        }

        public double CubicCapacity
        {
            get { return this.cubicCapacity; }
            private set { this.cubicCapacity = value; }
        }
    }
}
