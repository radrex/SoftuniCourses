namespace Cars
{
    public interface ICar
    {
        //----------- Properties -------------
        string Model { get; }
        string Color { get; }

        //------------ Methods ---------------
        string Start();
        string Stop();
    }
}
