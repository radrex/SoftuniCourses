namespace P07_RawData
{
    public class Car
    {
        //-------------- Constructors --------------
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, string[] tiresData)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tires = new Tire[4]
            {
                new Tire(double.Parse(tiresData[0]), int.Parse(tiresData[1])),
                new Tire(double.Parse(tiresData[2]), int.Parse(tiresData[3])),
                new Tire(double.Parse(tiresData[4]), int.Parse(tiresData[5])),
                new Tire(double.Parse(tiresData[6]), int.Parse(tiresData[7]))
            };
        }

        //--------------- Properties ---------------
        public string Model { get; private set; }

        public Engine Engine { get;  private set; }

        public Cargo Cargo { get; private set; }

        public Tire[] Tires { get; private set; }

        //---------------- Methods -----------------
        public override string ToString()
        {
            return $"{this.Model}";
        }
    }
}
