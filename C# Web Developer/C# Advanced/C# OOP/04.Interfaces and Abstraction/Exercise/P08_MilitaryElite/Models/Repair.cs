namespace P08_MilitaryElite.Models
{
    using Contracts;

    public class Repair : IRepair
    {
        //------------- Constructors ---------------
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        //-------------- Properties ----------------
        public string PartName { get; private set; }
        public int HoursWorked { get; private set; }

        //--------------- Methods ------------------
        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
