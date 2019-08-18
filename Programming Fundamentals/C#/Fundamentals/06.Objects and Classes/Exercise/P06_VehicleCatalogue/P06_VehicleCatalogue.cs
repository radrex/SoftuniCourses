namespace P06_VehicleCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P06_VehicleCatalogue
    {
        static void Main(string[] args)
        {
            VehicleCatalog vehicleCatalog = new VehicleCatalog();

            string[] vehicleData = Console.ReadLine().Split();
            while (vehicleData[0] != "End")
            {
                string type = vehicleData[0];
                string model = vehicleData[1];
                string color = vehicleData[2];
                int horsePower = int.Parse(vehicleData[3]);

                switch (type)
                {
                    case "car":
                        Car car = new Car()
                        {
                            Model = model,
                            Color = color,
                            Horsepower = horsePower
                        };
                        vehicleCatalog.Cars.Add(car);
                        break;

                    case "truck":
                        Truck truck = new Truck()
                        {
                            Model = model,
                            Color = color,
                            Horsepower = horsePower
                        };
                        vehicleCatalog.Trucks.Add(truck);
                        break;
                }

                vehicleData = Console.ReadLine().Split();
            }

            string command = Console.ReadLine();
            while (command != "Close the Catalogue")
            {
                if (vehicleCatalog.Cars.Any(c => c.Model == command))
                {
                    Car car = vehicleCatalog.Cars
                                            .Where(c => c.Model == command)
                                            .First();
                    Console.WriteLine($"Type: {car.GetType().Name}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Color: {car.Color}");
                    Console.WriteLine($"Horsepower: {car.Horsepower}");
                }

                if (vehicleCatalog.Trucks.Any(t => t.Model == command))
                {
                    Truck truck = vehicleCatalog.Trucks
                                                .Where(t => t.Model == command)
                                                .First();
                    Console.WriteLine($"Type: {truck.GetType().Name}");
                    Console.WriteLine($"Model: {truck.Model}");
                    Console.WriteLine($"Color: {truck.Color}");
                    Console.WriteLine($"Horsepower: {truck.Horsepower}");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(vehicleCatalog.Cars.Count == 0 ? "Cars have average horsepower of: 0.00." :
                $"Cars have average horsepower of: {(double)vehicleCatalog.Cars.Sum(c => c.Horsepower) / vehicleCatalog.Cars.Count:F2}.");

            Console.WriteLine(vehicleCatalog.Trucks.Count == 0 ? "Trucks have average horsepower of: 0.00." :
                $"Trucks have average horsepower of: {(double)vehicleCatalog.Trucks.Sum(t => t.Horsepower) / vehicleCatalog.Trucks.Count:F2}.");
        }
    }

    class VehicleCatalog
    {
        public VehicleCatalog()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }

    class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Truck
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }
}
