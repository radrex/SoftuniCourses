namespace P08_VehicleCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P08_VehicleCatalogue
    {
        static void Main(string[] args)
        {
            VehicleCatalog vehicleCatalog = new VehicleCatalog();
            string[] command = Console.ReadLine().Split('/');
            while (command[0] != "end")
            {
                string type = command[0];
                string brand = command[1];
                string model = command[2];

                switch (type)
                {
                    case "Car":
                        int horsePower = int.Parse(command[3]);
                        Car car = new Car()
                        {
                            Brand = brand,
                            Model = model,
                            HorsePower = horsePower
                        };

                        vehicleCatalog.Cars.Add(car);
                        break;

                    case "Truck":
                        int weight = int.Parse(command[3]);
                        Truck truck = new Truck()
                        {
                            Brand = brand,
                            Model = model,
                            Weight = weight
                        };

                        vehicleCatalog.Trucks.Add(truck);
                        break;
                }

                command = Console.ReadLine().Split('/');
            }

            if (vehicleCatalog.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in vehicleCatalog.Cars.OrderBy(c => c.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (vehicleCatalog.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in vehicleCatalog.Trucks.OrderBy(t => t.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
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
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }
    }

    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }
}