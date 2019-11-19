namespace P02_VehiclesExtension.Commands.VehicleCommands
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class DriveEmptyCommand : Command
    {
        //--------------- Constructors -----------------
        public DriveEmptyCommand() : base("DriveEmpty")
        {
            
        }

        //----------------- Methods --------------------
        public override void Run(string[] args)
        {
            throw new System.NotImplementedException();
        }

        public override void Run(string[] args, ICollection<Vehicle> vehicles)
        {
            foreach (Vehicle vehicle in vehicles.Where(v => v.GetType().Name == args[1]))
            {
                vehicle.DriveEmpty(double.Parse(args[2]));
            }
        }
    }
}
