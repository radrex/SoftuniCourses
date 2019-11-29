namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Patient
    {
        //------------- Properties --------------
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool HasInsurance { get; set; }

        //------------- Collections -------------
        public ICollection<Visitation> Visitations => new HashSet<Visitation>();
        public ICollection<Diagnose> Diagnoses => new HashSet<Diagnose>();
        public ICollection<PatientMedicament> Prescriptions => new HashSet<PatientMedicament>();
    }
}
