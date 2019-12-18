namespace P02_CarSalesman
{
    using System.Text;

    public class Car
    {
        //-------------------- Fields ------------------------
        private const string offset = "  ";

        //------------------ Constructors --------------------
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        //------------------- Properties ---------------------
        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public int Weight { get; private set; } = -1;
        public string Color { get; private set; } = "n/a";

        //-------------------- Methods -----------------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:\n", this.Model);
            sb.Append(this.Engine.ToString());
            sb.AppendFormat("{0}Weight: {1}\n", offset, this.Weight == -1 ? "n/a" : this.Weight.ToString());
            sb.AppendFormat("{0}Color: {1}", offset, this.Color);

            return sb.ToString();
        }
    }
}
