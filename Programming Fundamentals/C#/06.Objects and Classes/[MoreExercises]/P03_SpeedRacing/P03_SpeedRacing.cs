namespace P03_SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P03_SpeedRacing
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                double fuel = double.Parse(carData[1]);
                double consumption = double.Parse(carData[2]);

                if (cars.Any(c => c.Model == model))
                {
                    continue;
                }

                Car car = new Car()
                {
                    Model = model,
                    Fuel = fuel,
                    Consumption = consumption,
                    TravelledDistance = 0.0
                };
                cars.Add(car);
            }

            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                string model = command[1];
                double km = double.Parse(command[2]);
                cars.First(c => c.Model == model).Drive(km);

                command = Console.ReadLine().Split();
            }

            cars.ForEach(c => Console.WriteLine($"{c.Model} {c.Fuel:F2} {c.TravelledDistance}"));
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double Fuel { get; set; }
        public double Consumption { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double km)
        {
            if (this.Fuel - (this.Consumption * km) >= 0)
            {
                this.Fuel -= (this.Consumption * km);
                this.TravelledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}