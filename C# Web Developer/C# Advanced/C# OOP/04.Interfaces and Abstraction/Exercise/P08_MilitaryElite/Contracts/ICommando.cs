namespace P08_MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface ICommando
    {
        //--------- Properties ---------
        IReadOnlyCollection<IMission> Missions { get; }

        //---------- Methods -----------  
        void AddMission(IMission mission);
    }
}
