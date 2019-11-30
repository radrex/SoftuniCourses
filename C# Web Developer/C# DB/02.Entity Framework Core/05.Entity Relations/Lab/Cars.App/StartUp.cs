namespace Cars.App
{
    using Cars.Data;
    using Cars.Data.Models;
    using Cars.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new CarsDbContext();
            ResetDatabase(context);
        }

        private static void ResetDatabase(CarsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            Seed(context);
        }

        private static void Seed(CarsDbContext context)
        {
            var makes = new[]
            {
                new Make { Name = "Ford" },
                new Make { Name = "Mercedes" },
                new Make { Name = "Audi" },
                new Make { Name = "BMW" },
            };

            var engines = new[]
            {
                new Engine {Capacity = 1.6, Cyllinders = 4, FuelType = FuelType.Petrol, HorsePower = 95},
                new Engine {Capacity = 3.0, Cyllinders = 8, FuelType = FuelType.Diesel, HorsePower = 318},
                new Engine {Capacity = 1.2, Cyllinders = 3, FuelType = FuelType.Gas, HorsePower = 60},
            };

            var cars = new[]
            {
                new Car {Engine = engines[0], Make = makes[0], Doors = 4, Model = "Focus", ProductionYear = new DateTime(2001, 10, 12), Transmission = Transmission.Manual},
            };
            context.Cars.AddRange(cars);

            var dealerships = new[]
            {
                new Dealership {Name = "SoftUni-Auto"},
            };
            context.Dealerships.AddRange(dealerships);

            var carDealerships = new[]
            {
                new CarDealership {Car = cars[0], Dealership = dealerships[0]},
            };
            context.CarDealerships.AddRange(carDealerships);

            var licensePlates = new[]
            {
                new LicensePlate {Number = "CB1234AБ"},
            };
            context.LicensePlates.AddRange(licensePlates);
            context.SaveChanges();
        }
    }
}
