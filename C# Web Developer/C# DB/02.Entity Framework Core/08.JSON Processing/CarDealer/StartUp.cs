using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();  // Comment after initial create
                //db.Database.EnsureCreated();  // Comment after initial create

                //--------------------------------------------------------------------//
                //                            IMPORT DATA                             //
                //--------------------------------------------------------------------//

                //---- TASK 09 ---- IMPORT SUPPLIERS -----------------------------------
                /*
                    string jsonText = File.ReadAllText("../../../Datasets/suppliers.json");
                    string result = ImportSuppliers(db, jsonText);
                    Console.WriteLine(result);
                */

                //---- TASK 10 ---- IMPORT PARTS ---------------------------------------
                /*
                    string jsonText = File.ReadAllText("../../../Datasets/parts.json");
                    string result = ImportParts(db, jsonText);
                    Console.WriteLine(result);
                */

                //---- TASK 11 ---- IMPORT CARS ----------------------------------------
                /*
                    string jsonText = File.ReadAllText("../../../Datasets/cars.json");
                    string result = ImportCars(db, jsonText);
                    Console.WriteLine(result);
                */

                //---- TASK 12 ---- IMPORT CUSTOMERS -----------------------------------
                /*
                    string jsonText = File.ReadAllText("../../../Datasets/customers.json");
                    string result = ImportCustomers(db, jsonText);
                    Console.WriteLine(result);
                */

                //---- TASK 13 ---- IMPORT SALES ---------------------------------------
                /*
                    string jsonText = File.ReadAllText("../../../Datasets/sales.json");
                    string result = ImportSales(db, jsonText);
                    Console.WriteLine(result);
                */

                //--------------------------------------------------------------------//
                //                            EXPORT DATA                             //
                //--------------------------------------------------------------------//

                //---- TASK 14 ---- EXPORT ORDERED CUSTOMERS ---------------------------
                /*
                    string result = GetOrderedCustomers(db);
                    Console.WriteLine(result);
                */
                //---- TASK 15 ---- EXPORT CARS FROM MAKE TOYOTA -----------------------
                /*
                    string result = GetCarsFromMakeToyota(db);
                    Console.WriteLine(result);
                */
                //---- TASK 16 ---- EXPORT LOCAL SUPPLERS ------------------------------
                /*
                    string result = GetLocalSuppliers(db);
                    Console.WriteLine(result);
                */
                //---- TASK 17 ---- EXPORT CARS WITH THEIR LIST OF PARTS ---------------
                /*
                    string result = GetCarsWithTheirListOfParts(db); //TODO IMPLEMENT
                    Console.WriteLine(result);
                */
                //---- TASK 18 ---- EXPORT TOTAL SALES BY CUSTOMER ---------------------
                /*
                    string result = GetTotalSalesByCustomer(db); //TODO IMPLEMENT
                    Console.WriteLine(result);
                */
                //---- TASK 19 ---- EXPORT SALES WITH APPLIED DISCOUNT -----------------
                //TODO IMPLEMENT
            }
        }

        //------------------- TASK 09 ---- IMPORT SUPPLIERS -------------------------------------
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }
        //------------------- TASK 10 ---- IMPORT PARTS -----------------------------------------
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                                      .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                                      .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }
        //------------------- TASK 11 ---- IMPORT CARS ------------------------------------------
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            List<Car> cars = new List<Car>();
            List<PartCar> carParts = new List<PartCar>();

            foreach (ImportCarDto carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,
                };

                //partsId array
                foreach (var partId in carDto.PartsId.Distinct())
                {
                    PartCar carPart = new PartCar()
                    {
                        PartId = partId,
                        Car = car,
                    };
                    carParts.Add(carPart);
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
        //------------------- TASK 12 ---- IMPORT CUSTOMERS -------------------------------------
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }
        //------------------- TASK 13 ---- IMPORT SALES -----------------------------------------
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }
        //------------------- TASK 14 ---- EXPORT ORDERED CUSTOMERS -----------------------------
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers.OrderBy(c => c.BirthDate)
                                             .ThenBy(c => c.IsYoungDriver)
                                             .Select(c => new
                                             {
                                                 Name = c.Name,
                                                 BirthDate = $"{c.BirthDate.Day}/{c.BirthDate.Month}/{c.BirthDate.Year}",
                                                 IsYoungDriver = c.IsYoungDriver,
                                             })
                                             .ToArray();

            string json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
            return json;
        }
        //------------------- TASK 15 ---- EXPORT CARS FROM MAKE TOYOTA -------------------------
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.Make == "Toyota")
                                   .OrderBy(c => c.Model)
                                   .ThenByDescending(c => c.TravelledDistance)
                                   .Select(c => new
                                   {
                                       Id = c.Id,
                                       Make = c.Make,
                                       Model = c.Model,
                                       TravelledDistance = c.TravelledDistance,
                                   })
                                   .ToArray();
            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented
            });
            return json;
        }
        //------------------- TASK 16 ---- EXPORT LOCAL SUPPLERS --------------------------------
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(s => s.IsImporter == false)
                                             .Select(s => new
                                             {
                                                 Id = s.Id,
                                                 Name = s.Name,
                                                 PartsCount = s.Parts.Count,
                                             })
                                             .ToArray();
            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(suppliers, new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented
            });
            return json;
        }
        //------------------- TASK 17 ---- EXPORT CARS WITH THEIR LIST OF PARTS -----------------
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //TODO implement
            return "";
        }
        //------------------- TASK 18 ---- EXPORT TOTAL SALES BY CUSTOMER -----------------------
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //TODO implement
            return "";
        }
        //------------------- TASK 19 ---- EXPORT SALES WITH APPLIED DISCOUNT -------------------
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //TODO implement
            return "";
        }
    }
}