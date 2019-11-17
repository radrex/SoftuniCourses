namespace P08_MilitaryElite.Contracts
{
    public interface IRepair
    {
        //--------- Properties ---------
        string PartName { get; }
        int HoursWorked { get; }
    }
}
