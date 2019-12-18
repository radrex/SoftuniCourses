namespace P04_Hospital.Models
{
    public class Bed
    {
        //-------------- Constructors ----------------
        public Bed() { }

        //--------------- Properties -----------------
        public bool IsOccupied { get; private set; }

        public Patient Patient { get; private set; }

        //------------- Public Methods ---------------
        public void Occupy(Patient patient)
        {
            this.IsOccupied = true;
            this.Patient = patient;
        }
    }
}
