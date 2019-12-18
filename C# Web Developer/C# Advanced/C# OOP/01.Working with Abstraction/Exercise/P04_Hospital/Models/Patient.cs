namespace P04_Hospital.Models
{
    public class Patient
    {
        //-------------- Constructors ----------------
        public Patient(string name)
        {
            this.Name = name;
        }

        //--------------- Properties -----------------
        public string Name { get; private set; }

        //------------- Public Methods ---------------
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
