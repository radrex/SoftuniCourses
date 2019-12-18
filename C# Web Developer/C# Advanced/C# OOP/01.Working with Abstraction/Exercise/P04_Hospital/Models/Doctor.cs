namespace P04_Hospital.Models
{
    using System.Collections.Generic;

    public class Doctor
    {
        //---------------- Fields --------------------
        private List<Patient> patients;

        //-------------- Constructors ----------------
        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.patients = new List<Patient>();
        }

        //--------------- Properties -----------------
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IReadOnlyCollection<Patient> Patients => this.patients.AsReadOnly();

        //------------- Public Methods ---------------
        public void AddPatient(Patient patient)
        {
            this.patients.Add(patient);
        }
    }
}
