using System.Collections.Generic;

namespace P03_DetailPrinter_Before
{
    public class Manager : Employee
    {
        //---------- Constructors ----------
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        //----------- Properties -----------
        public IReadOnlyCollection<string> Documents { get; set; }
    }
}
