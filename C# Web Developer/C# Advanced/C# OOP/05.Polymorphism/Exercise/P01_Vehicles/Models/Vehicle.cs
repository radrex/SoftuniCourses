namespace P01_Vehicles.Models
{
    using Contracts;
    using System;

    public abstract class Vehicle : IDriveable, IRefuelable
    {
        //--------------- Fields -------------------
        private double fuelQuantity;
        private double fuelConsumption;

        //------------- Constructors ---------------
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
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
                this.fuelQuantity = value;
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

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
