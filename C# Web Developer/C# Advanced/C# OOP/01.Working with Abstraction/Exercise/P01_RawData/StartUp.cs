namespace P01_RawData
{
    using P01_RawData.CarComponents;
    using P01_RawData.CarComponents.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Car> cars = new HashSet<Car>(new CarComparer());
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                CargoType cargoType = Enum.Parse<CargoType>(carData[4]);

                Tire[] tires = new Tire[]
                {
                    new Tire(double.Parse(carData[5]), int.Parse(carData[6])),
                    new Tire(double.Parse(carData[7]), int.Parse(carData[8])),
                    new Tire(double.Parse(carData[9]), int.Parse(carData[10])),
                    new Tire(double.Parse(carData[11]), int.Parse(carData[12])),
                };

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                try
                {
                    Car car = new Car(model, engine, cargo, tires);
                    cars.Add(car);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    cars.Where(c => c.Cargo.CargoType.ToString() == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;

                case "flamable":
                    cars.Where(c => c.Cargo.CargoType.ToString() == "flamable" && c.Engine.Power > 250)
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;

                default:
                    break;
            }
        }
    }
}
