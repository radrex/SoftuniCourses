using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        //---------- Constructors ------------
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        //----------- Properties -------------
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
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());
            return sb.ToString().TrimEnd();
        }
    }
}
