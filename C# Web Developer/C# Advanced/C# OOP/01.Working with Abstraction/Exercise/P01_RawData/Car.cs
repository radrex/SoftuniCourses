namespace P01_RawData
{
    using P01_RawData.CarComponents;
    using System;

    public class Car
    {
        //---------------- Fields --------------------
        private Tire[] tires;

        //-------------- Constructors ----------------
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        //--------------- Properties -----------------
        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public Cargo Cargo { get; private set; }
        public Tire[] Tires
        {
            get
            {
                return this.tires;
            }
            private set
            {
                if (value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException("Only 4 tires allowed");
                }

                this.tires = value;
            }
        }
    }
}
