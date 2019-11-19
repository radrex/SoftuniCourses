namespace P02_VehiclesExtension.Commands
{
    public interface ICommand
    {
        //--------- Properties ----------
        string Name { get; }

        //---------- Methods ------------
        void Run(string[] args);
    }
}
