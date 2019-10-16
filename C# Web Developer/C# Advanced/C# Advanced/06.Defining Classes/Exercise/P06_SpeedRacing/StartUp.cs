namespace P06_SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                double fuel = double.Parse(carData[1]);
                double distance = double.Parse(carData[2]);

                if (!cars.ContainsKey(model))
                {
                    Car car = new Car(model, fuel, distance);
                    cars[car.Model] = car;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] driveData = command.Split();
                string model = driveData[1];
                double distance = double.Parse(driveData[2]);

                KeyValuePair<string, Car> car = cars.FirstOrDefault(c => c.Key == model);
                if (car.Key != null)
                {
                    cars[model].Drive(distance);
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, cars.Values));
        }
    }
}
