namespace P08_MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Enums;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        //---------------- Fields ------------------
        private List<IRepair> repairs;

        //------------- Constructors ---------------
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, params IRepair[] repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>(repairs);
        }

        //-------------- Properties ----------------
        public IReadOnlyCollection<IRepair> Repairs => this.repairs.AsReadOnly();

        //--------------- Methods ------------------
        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            sb.Append("  " + String.Join(Environment.NewLine + "  ", this.Repairs));
            return sb.ToString().TrimEnd();
        }
    }
}
