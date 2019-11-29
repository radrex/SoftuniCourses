namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Doctor
    {
        //-- TASK 02 -- Hospital Database Modification

        //------------- Properties --------------
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }

        //------------- Collections -------------
        public ICollection<Visitation> Visitations => new HashSet<Visitation>();
    }
}
