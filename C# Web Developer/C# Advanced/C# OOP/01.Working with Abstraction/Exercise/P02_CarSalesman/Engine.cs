namespace P02_CarSalesman
{
    using System.Text;

    public class Engine
    {
        //-------------------- Fields ------------------------
        private const string offset = "  ";

        //------------------ Constructors --------------------
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        //------------------- Properties ---------------------
        public string Model { get; private set; }
        public int Power { get; private set; }
        public int Displacement { get; private set; } = -1;
        public string Efficiency { get; private set; } = "n/a";

        //-------------------- Methods -----------------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:\n", offset, this.Model);
            sb.AppendFormat("{0}{0}Power: {1}\n", offset, this.Power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.Displacement == -1 ? "n/a" : this.Displacement.ToString());
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.Efficiency);

            return sb.ToString();
        }
    }
}
