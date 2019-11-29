namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        //------------- Properties --------------
        public int DiagnoseId { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }

        //-------- Patient -------- [FK]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
