namespace P07_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];
                string[] tiresData = new string[8]
                {
                    carData[5],  carData[6],
                    carData[7],  carData[8],
                    carData[9],  carData[10],
                    carData[11], carData[12]
                };

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tiresData);
                cars.Add(car);
            }

            string type = Console.ReadLine();
            switch (type)
            {
                case "fragile":
                    Console.WriteLine(String.Join(Environment.NewLine, cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))));
                    break;

                case "flamable":
                    Console.WriteLine(String.Join(Environment.NewLine, cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)));
                    break;

                default:
                    break;
            }
        }
    }
}
