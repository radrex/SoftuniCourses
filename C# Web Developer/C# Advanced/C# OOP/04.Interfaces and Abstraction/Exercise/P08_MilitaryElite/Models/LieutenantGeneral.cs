namespace P08_MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        //---------------- Fields ------------------
        private List<IPrivate> privates;

        //------------- Constructors ---------------
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, params IPrivate[] privates) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>(privates);
        }

        //-------------- Properties ----------------
        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();

        //--------------- Methods ------------------
        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            sb.Append("  " + String.Join(Environment.NewLine + "  ", this.Privates));
            return sb.ToString().TrimEnd();
        }
    }
}
