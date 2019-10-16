namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Parking
    {
        //----------------- Fields -----------------
        private HashSet<Car> cars;
        private int capacity;

        //-------------- Constructors --------------
        public Parking(int capacity)
        {
            this.Cars = new HashSet<Car>(new CarRegistrationNumberComparer());
            this.Capacity = capacity;
        }

        //--------------- Properties ---------------
        public HashSet<Car> Cars
        {
            get { return this.cars; }
            private set { this.cars = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int Count
        {
            get { return this.Cars.Count; }
        }

        //---------------- Methods -----------------
        private class CarRegistrationNumberComparer : IEqualityComparer<Car>
        {
            public bool Equals(Car x, Car y)
            {
                return x.RegistrationNumber.Equals(y.RegistrationNumber, StringComparison.InvariantCultureIgnoreCase);
            }

            public int GetHashCode(Car obj)
            {
                return obj.RegistrationNumber.GetHashCode();
            }
        }

        public string AddCar(Car car)
        {
            if (this.Cars.Contains(car))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.Cars.Count >= this.Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                this.Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            if (car != null)
            {
                this.Cars.Remove(car);
                return $"Successfully removed {car.RegistrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return this.Cars.First(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            Func<Car, string, bool> filter = (c, registrationNumber) => c.RegistrationNumber == registrationNumber;
            foreach (string registrationNumber in registrationNumbers)
            {
                this.Cars.RemoveWhere(c => filter(c, registrationNumber));
            }
        }
    }
}
