namespace P01_Vehicles.Commands
{
    public interface ICommand
    {
        //--------- Properties ----------
        string Name { get; }

        //---------- Methods ------------
        void Run(string[] args);
    }
}
