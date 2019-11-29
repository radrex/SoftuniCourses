namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Medicament
    {
        //------------- Properties --------------
        public int MedicamentId { get; set; }
        public string Name { get; set; }

        //------------- Collections -------------
        public ICollection<PatientMedicament> Prescriptions => new HashSet<PatientMedicament>();
    }
}
