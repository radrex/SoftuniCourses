namespace P04_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P04_RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];

                Engine engine = new Engine()
                {
                    Speed = engineSpeed,
                    Power = enginePower
                };

                Cargo cargo = new Cargo()
                {
                    Weight = cargoWeight,
                    Type = cargoType
                };

                Car car = new Car(model, engine, cargo);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    cars.Where(c => c.Cargo.Type == "fragile" && c.Cargo.Weight < 1000)
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;

                case "flamable":
                    cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;
            }
        }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }

    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }
    }

    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }
    }
}