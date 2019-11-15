namespace Cars
{
    using System.Text;

    public class Tesla : ICar, IElectricCar
    {
        //---------- Constructors ------------
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        //----------- Properties -------------
        public int Battery
        {
            get;
        }

        public string Model
        {
            get;
        }

        public string Color
        {
            get;
        }

        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }

        //------------ Methods ---------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());
            return sb.ToString().TrimEnd();
        }
    }
}
