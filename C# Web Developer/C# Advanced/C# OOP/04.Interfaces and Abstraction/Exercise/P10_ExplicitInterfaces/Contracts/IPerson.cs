namespace P10_ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        //---------- Properties ------------
        string Name { get; }
        int Age { get; }

        //----------- Methods --------------
        string GetName();
    }
}
