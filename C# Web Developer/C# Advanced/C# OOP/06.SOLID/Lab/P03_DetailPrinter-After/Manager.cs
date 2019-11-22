namespace P03_DetailPrinter_After
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Manager : Employee
    {
        //------------- Fields -------------
        private IReadOnlyCollection<string> documents;

        //---------- Constructors ----------
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.documents = new List<string>(documents);
        }

        //----------- Properties -----------
        public IReadOnlyCollection<string> Documents => this.documents;

        //------------ Methods -------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Documents: {String.Join(", ", this.Documents)}");

            return sb.ToString().TrimEnd();
        }
    }
}
