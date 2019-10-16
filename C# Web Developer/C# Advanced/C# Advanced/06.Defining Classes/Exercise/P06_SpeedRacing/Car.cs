namespace P06_SpeedRacing
{
    using System;

    public class Car
    {
        //-------------- Constructors --------------
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        //--------------- Properties ---------------
        public string Model { get; private set; }

        public double FuelAmount { get; private set; }

        public double FuelConsumptionPerKilometer { get; private set; }

        public double TravelledDistance { get; private set; }

        //---------------- Methods -----------------
        public void Drive(double distance)
        {
            if (this.FuelConsumptionPerKilometer * distance <= this.FuelAmount)
            {
                this.FuelAmount -= this.FuelConsumptionPerKilometer * distance;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}
