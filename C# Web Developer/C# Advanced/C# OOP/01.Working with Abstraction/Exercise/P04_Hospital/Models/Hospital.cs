namespace P04_Hospital.Models
{
    using System.Collections.Generic;

    public class Hospital
    {
        //---------------- Fields --------------------
        private List<Department> departments;

        //-------------- Constructors ----------------
        public Hospital()
        {
            this.departments = new List<Department>();
        }

        //--------------- Properties -----------------
        public IReadOnlyCollection<Department> Departments => this.departments.AsReadOnly();

        //------------- Public Methods ---------------
        public void AddDepartment(Department department)
        {
            this.departments.Add(department);
        }
    }
}
