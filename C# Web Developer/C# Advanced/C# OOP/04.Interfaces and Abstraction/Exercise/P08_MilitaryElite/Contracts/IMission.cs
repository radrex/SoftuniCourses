namespace P08_MilitaryElite.Contracts
{
    using Enums;

    public interface IMission
    {
        //--------- Properties ---------
        string CodeName { get; }
        MissionState MissionState { get; }

        //---------- Methods -----------
        void CompleteMission();
    }
}
