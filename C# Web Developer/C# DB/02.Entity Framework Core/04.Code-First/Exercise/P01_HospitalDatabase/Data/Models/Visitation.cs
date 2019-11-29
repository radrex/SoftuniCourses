namespace P01_HospitalDatabase.Data.Models
{
    using System;

    public class Visitation
    {
        //------------- Properties --------------
        public int VisitationId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }

        //-------- Patient -------- [FK]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }


        //-- TASK 02 -- Hospital Database Modification

        //--------- Doctor -------- [FK]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
