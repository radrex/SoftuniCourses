namespace P08_MilitaryElite.Models
{
    using Contracts;
    using System;

    public class Spy : Soldier, ISpy
    {
        //------------- Constructors ---------------
        public Spy(int id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        //-------------- Properties ----------------
        public int CodeNumber { get; private set; }

        //--------------- Methods ------------------
        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine +
                   $"Code Number: {this.CodeNumber}";
        }
    }
}
