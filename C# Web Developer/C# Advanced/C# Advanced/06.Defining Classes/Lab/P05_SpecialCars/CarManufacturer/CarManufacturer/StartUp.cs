namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "No more tires")
                {
                    break;
                }

                string[] tiresData = command.Split();
                List<Tire> tiresList = new List<Tire>();

                for (int i = 0; i < tiresData.Length; i+=2)
                {
                    int year = int.Parse(tiresData[i]);
                    double pressure = double.Parse(tiresData[i + 1]);
                    Tire tire = new Tire(year, pressure);
                    tiresList.Add(tire);
                }

                tires.Add(tiresList.ToArray());
            }

            List<Engine> engines = new List<Engine>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Engines done")
                {
                    break;
                }

                string[] enginesData = command.Split();
                int horsePower = int.Parse(enginesData[0]);
                double cubicCapacity = double.Parse(enginesData[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Show special")
                {
                    break;
                }

                string[] carData = command.Split();
                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }

            Func<Car, bool> filter = c => c.Year >= 2017 && 
                                          c.Engine.HorsePower > 330 && 
                                          c.Tires.Sum(t => t.Pressure) >= 9 && 
                                          c.Tires.Sum(t => t.Pressure) <= 10;

            List<Car> specialCars = new List<Car>();
            foreach (Car car in cars.Where(filter))
            {
                car.Drive(20);
                specialCars.Add(car);
            }

            Console.WriteLine(String.Join("", specialCars));
        }
    }
}
