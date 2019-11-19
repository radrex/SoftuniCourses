namespace P02_VehiclesExtension.Models
{
    using Contracts;
    using System;

    public abstract class Vehicle : IDriveable, IRefuelable
    {
        //--------------- Fields -------------------
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        //------------- Constructors ---------------
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        //-------------- Properties ----------------
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Fuel quantity cannot be less than zero");
                }
                this.fuelQuantity = (value > this.TankCapacity) ? 0 : value;
            }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be less than or equal to zero");
                }
                this.fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Tank capacity cannot be less than zero");
                }
                this.tankCapacity = value;
            }
        }

        //--------------- Methods ------------------
        public void Drive(double distance)
        {
            double fuel = this.FuelConsumption * distance;
            if (fuel > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public void DriveEmpty(double distance)
        {
            this.FuelConsumption -= 1.4;
            this.Drive(distance);
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (fuel > this.TankCapacity - this.fuelQuantity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
