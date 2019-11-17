namespace P08_MilitaryElite.Models
{
    using Contracts;
    using System;

    public class Private : Soldier, IPrivate
    {
        //------------- Constructors ---------------
        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        //-------------- Properties ----------------
        public decimal Salary { get; private set; }

        //--------------- Methods ------------------
        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:F2}";
        }
    }
}
