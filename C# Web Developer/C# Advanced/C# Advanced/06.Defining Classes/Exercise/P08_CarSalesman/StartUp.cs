namespace P08_CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int enginesCount = int.Parse(Console.ReadLine());
            while (enginesCount-- > 0)
            {
                string[] engineData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                Engine engine = new Engine(model, power);

                if (engineData.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(engineData[2], out displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                    }
                }
                else if (engineData.Length == 4)
                {
                    int displacement;
                    if (int.TryParse(engineData[2], out displacement))
                    {
                        engine.Displacement = displacement;
                        engine.Efficiency = engineData[3];
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                        engine.Displacement = int.Parse(engineData[3]);
                    }
                }

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());
            while (carsCount-- > 0)
            {
                string[] carsData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carsData[0];
                Engine engine = engines.Where(e => e.Model == carsData[1]).First();
                Car car = new Car(model, engine);

                if (carsData.Length == 3)
                {
                    int weight;
                    if (int.TryParse(carsData[2], out weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carsData[2];
                    }
                }
                else if (carsData.Length == 4)
                {
                    int weight;
                    if (int.TryParse(carsData[2], out weight))
                    {
                        car.Weight = weight;
                        car.Color = carsData[3];
                    }
                    else
                    {
                        car.Color = carsData[2];
                        car.Weight = int.Parse(carsData[3]);
                    }
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
