namespace SoftUniParking
{
    using System.Text;

    public class Car
    {
        //-------------- Constructors --------------
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        //--------------- Properties ---------------
        public string Make { get; private set; }

        public string Model { get; private set; }

        public int HorsePower { get; private set; }

        public string RegistrationNumber { get; private set; }

        //------------Methods-------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"HorsePower: {this.HorsePower}");
            sb.Append($"RegistrationNumber: {this.RegistrationNumber}");
            return sb.ToString();
        }
    }
}
