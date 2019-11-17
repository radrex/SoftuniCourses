namespace P10_ExplicitInterfaces.Contracts
{
    public interface IResident
    {
        //---------- Properties ------------
        string Name { get; }
        string Country { get; }

        //----------- Methods --------------
        string GetName();
    }
}
