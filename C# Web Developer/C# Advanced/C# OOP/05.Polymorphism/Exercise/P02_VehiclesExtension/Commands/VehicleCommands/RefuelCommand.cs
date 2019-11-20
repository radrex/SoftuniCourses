namespace P02_VehiclesExtension.Commands.VehicleCommands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class RefuelCommand : Command
    {
        //--------------- Constructors -----------------
        public RefuelCommand() : base("Refuel")
        {

        }

        //----------------- Methods --------------------
        public override void Run(string[] args)
        {
            Console.WriteLine("For testing purposes");
            //throw new NotImplementedException(); -> Liskov Substitution Violation if thrown...
        }

        public override void Run(string[] args, ICollection<Vehicle> vehicles)
        {
            foreach (Vehicle vehicle in vehicles.Where(v => v.GetType().Name == args[1]))
            {
                vehicle.Refuel(double.Parse(args[2]));
            }
        }
    }
}
