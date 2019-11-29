namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        //------------- Properties --------------

        //-------- Patient -------- [FK]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        //------- Medicament ------ [FK]
        public int MedicamentId { get; set; }
        public Medicament Medicament { get; set; }
    }
}
