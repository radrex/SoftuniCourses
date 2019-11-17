namespace P08_MilitaryElite.Models
{
    using Contracts;
    using Enums;
    using System;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        //------------- Constructors ---------------
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        //-------------- Properties ----------------
        public Corps Corps { get; private set; }

        //--------------- Methods ------------------
        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine +
                   $"Corps: {this.Corps}";
        }
    }
}
