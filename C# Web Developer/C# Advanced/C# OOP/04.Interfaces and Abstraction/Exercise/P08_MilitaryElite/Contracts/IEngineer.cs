namespace P08_MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface IEngineer
    {
        //--------- Properties ---------
        IReadOnlyCollection<IRepair> Repairs { get; }

        //---------- Methods -----------
        void AddRepair(IRepair repair);

    }
}
