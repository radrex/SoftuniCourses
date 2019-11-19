namespace P02_VehiclesExtension.Commands
{
    using Models;
    using System.Collections.Generic;

    public abstract class Command : ICommand
    {
        //----------------- Fields ---------------------
        private string name;

        //--------------- Constructors -----------------
        protected Command(string name)
        {
            this.Name = name;
        }

        //---------------- Properties ------------------
        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        //------------- Abstract Methods ---------------
        public abstract void Run(string[] args);

        public abstract void Run(string[] args, ICollection<Vehicle> vehicles);
    }
}
