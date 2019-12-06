namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using System.Linq;
    using CarDealer.Dtos.Export;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();  // Comment after initial create
                //db.Database.EnsureCreated();  // Comment after initial create

                //--------------------------------------------------------------------//
                //                            IMPORT DATA                             //
                //--------------------------------------------------------------------//

                //---- TASK 09 ---- IMPORT SUPPLIERS -----------------------------------
                /*
                    string xmlText = File.ReadAllText("../../../Datasets/suppliers.xml");
                    string result = ImportSuppliers(db, xmlText);
                    Console.WriteLine(result);
                */
                //---- TASK 10 ---- IMPORT PARTS ---------------------------------------
                /*
                    string xmlText = File.ReadAllText("../../../Datasets/parts.xml");
                    string result = ImportParts(db, xmlText);
                    Console.WriteLine(result);
                */
                //---- TASK 11 ---- IMPORT CARS ----------------------------------------
                /*
                    string xmlText = File.ReadAllText("../../../Datasets/cars.xml");
                    string result = ImportCars(db, xmlText);
                    Console.WriteLine(result);
                */
                //---- TASK 12 ---- IMPORT CUSTOMERS -----------------------------------
                /*
                    string xmlText = File.ReadAllText("../../../Datasets/customers.xml");
                    string result = ImportCustomers(db, xmlText);
                    Console.WriteLine(result);
                */
                //---- TASK 13 ---- IMPORT SALES ---------------------------------------
                /*
                    string xmlText = File.ReadAllText("../../../Datasets/sales.xml");
                    string result = ImportSales(db, xmlText);
                    Console.WriteLine(result);
                */
                //--------------------------------------------------------------------//
                //                            EXPORT DATA                             //
                //--------------------------------------------------------------------//

                //---- TASK 14 ---- EXPORT ORDERED CUSTOMERS ---------------------------
                /*
                    string result = GetCarsWithDistance(db);
                    Console.WriteLine(result);
                */

                //---- TASK 15 ---- EXPORT CARS FROM MAKE TOYOTA -----------------------
                /*
                    string result = GetCarsFromMakeBmw(db);
                    Console.WriteLine(result);
                */

                //---- TASK 16 ---- EXPORT LOCAL SUPPLERS ------------------------------
                /*
                    string result = GetLocalSuppliers(db);
                    Console.WriteLine(result);
                */

                //---- TASK 17 ---- EXPORT CARS WITH THEIR LIST OF PARTS ---------------
                /*
                    string result = GetCarsWithTheirListOfParts(db);
                    Console.WriteLine(result);
                */
                //---- TASK 18 ---- EXPORT TOTAL SALES BY CUSTOMER ---------------------
                /*
                    string result = GetTotalSalesByCustomer(db);    //TODO MEMORY LIMIT JUDGE
                    Console.WriteLine(result);
                */
                //---- TASK 19 ---- EXPORT SALES WITH APPLIED DISCOUNT -----------------
                string result = GetSalesWithAppliedDiscount(db);    //TODO WRONG OUTPUT PROBABLY ON DISCOUNT CALCULATIONS
                Console.WriteLine(result);

            }
        }

        //------------------- TASK 09 ---- IMPORT SUPPLIERS -------------------------------------
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            //-------------------- WITH AUTOMAPPER AND DTO --------------------
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            //ImportSupplierDto[] supplierDtos;
            //using (var reader = new StringReader(inputXml))
            //{
            //    supplierDtos = xmlSerializer.Deserialize(reader) as ImportSupplierDto[];
            //}

            //Supplier[] suppliers = Mapper.Map<Supplier[]>(supplierDtos);

            //context.Suppliers.AddRange(suppliers);
            //context.SaveChanges();

            //return $"Successfully imported {suppliers.Length}";

            //-------------------- WITH MANUAL MAPPING --------------------
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] supplierDtos;
            using (var reader = new StringReader(inputXml))
            {
                supplierDtos = xmlSerializer.Deserialize(reader) as ImportSupplierDto[];
            }

            List<Supplier> suppliers = new List<Supplier>();
            foreach (ImportSupplierDto dto in supplierDtos)
            {
                Supplier supplier = new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter,
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}";
        }
        //------------------- TASK 10 ---- IMPORT PARTS -----------------------------------------
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            //-------------------- WITH AUTOMAPPER AND DTO --------------------
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            //ImportPartDto[] partDtos;
            //using (var reader = new StringReader(inputXml))
            //{
            //    partDtos = (xmlSerializer.Deserialize(reader) as ImportPartDto[]).Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId)).ToArray();
            //}

            //Part[] parts = Mapper.Map<Part[]>(partDtos);
            //context.Parts.AddRange(parts);
            //context.SaveChanges();

            //return $"Successfully imported {parts.Length}";

            //-------------------- WITH MANUAL MAPPING --------------------
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            ImportPartDto[] partDtos;
            using (var reader = new StringReader(inputXml))
            {
                partDtos = (xmlSerializer.Deserialize(reader) as ImportPartDto[]).Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId)).ToArray();
            }

            List<Part> parts = new List<Part>();
            foreach (ImportPartDto dto in partDtos)
            {
                Part part = new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId,
                };
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
        //------------------- TASK 11 ---- IMPORT CARS ------------------------------------------
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            ImportCarDto[] carDtos;
            using (var reader = new StringReader(inputXml))
            {
                carDtos = (xmlSerializer.Deserialize(reader) as ImportCarDto[]);
            }

            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();

            foreach (ImportCarDto carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,
                };

                var parts = carDto.Parts.Where(pdto => context.Parts.Any(p => p.Id == pdto.Id))
                                        .Select(p => p.Id)
                                        .Distinct();

                foreach (var partId in parts)
                {
                    PartCar partCar = new PartCar()
                    {
                        PartId = partId,
                        Car = car,
                    };
                    partCars.Add(partCar);
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        //------------------- TASK 12 ---- IMPORT CUSTOMERS -------------------------------------
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            //-------------------- WITH AUTOMAPPER AND DTO --------------------
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            //ImportCustomerDto[] customerDtos;
            //using (var reader = new StringReader(inputXml))
            //{
            //    customerDtos = xmlSerializer.Deserialize(reader) as ImportCustomerDto[];
            //}

            //Customer[] customers = Mapper.Map<Customer[]>(customerDtos);

            //context.Customers.AddRange(customers);
            //context.SaveChanges();

            //return $"Successfully imported {customers.Length}";

            //-------------------- WITH MANUAL MAPPING --------------------
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            ImportCustomerDto[] customerDtos;
            using (var reader = new StringReader(inputXml))
            {
                customerDtos = xmlSerializer.Deserialize(reader) as ImportCustomerDto[];
            }

            List<Customer> customers = new List<Customer>();
            foreach (ImportCustomerDto dto in customerDtos)
            {
                Customer customer = new Customer()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver,
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}";
        }
        //------------------- TASK 13 ---- IMPORT SALES -----------------------------------------
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            //-------------------- WITH AUTOMAPPER AND DTO --------------------
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            //ImportSaleDto[] saleDtos;
            //using (var reader = new StringReader(inputXml))
            //{
            //    saleDtos = (xmlSerializer.Deserialize(reader) as ImportSaleDto[]).Where(p => context.Cars.Any(c => c.Id == p.CarId)).ToArray();
            //}

            //Sale[] sales = Mapper.Map<Sale[]>(saleDtos);

            //context.Sales.AddRange(sales);
            //context.SaveChanges();

            //return $"Successfully imported {sales.Length}";

            //-------------------- WITH MANUAL MAPPING --------------------
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            ImportSaleDto[] saleDtos;
            using (var reader = new StringReader(inputXml))
            {
                saleDtos = (xmlSerializer.Deserialize(reader) as ImportSaleDto[]).Where(p => context.Cars.Any(c => c.Id == p.CarId)).ToArray();
            }

            List<Sale> sales = new List<Sale>();
            foreach (ImportSaleDto dto in saleDtos)
            {
                Sale sale = new Sale()
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount,
                };
                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
        //------------------- TASK 14 ---- EXPORT ORDERED CUSTOMERS -----------------------------
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarDto[] cars = context.Cars.Where(c => c.TravelledDistance > 2000000)
                                              .Select(c => new ExportCarDto
                                              {
                                                  Make = c.Make,
                                                  Model = c.Model,
                                                  TravelledDistance = c.TravelledDistance,
                                              })
                                              .OrderBy(c => c.Make)
                                              .ThenBy(c => c.Model)
                                              .Take(10)
                                              .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 15 ---- EXPORT CARS FROM MAKE TOYOTA -------------------------
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportBMWCarDto[] bmws = context.Cars.Where(c => c.Make == "BMW")
                                                 .Select(c => new ExportBMWCarDto
                                                 {
                                                     Id = c.Id,
                                                     Model = c.Model,
                                                     TravelledDistance = c.TravelledDistance,
                                                 })
                                                 .OrderBy(c => c.Model)
                                                 .ThenByDescending(c => c.TravelledDistance)
                                                 .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBMWCarDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, bmws, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 16 ---- EXPORT LOCAL SUPPLERS --------------------------------
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSupplierDto[] localSuppliers = context.Suppliers.Where(s => !s.IsImporter)
                                                                       .Select(s => new ExportLocalSupplierDto
                                                                       {
                                                                           Id = s.Id,
                                                                           Name = s.Name,
                                                                           PartsCount = s.Parts.Count,
                                                                       })
                                                                       .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), new XmlRootAttribute("suppliers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, localSuppliers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //------------------- TASK 17 ---- EXPORT CARS WITH THEIR LIST OF PARTS -----------------
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarPartDto[] carParts = context.Cars.Select(c => new ExportCarPartDto
                                                                   {
                                                                        Make = c.Make,
                                                                        Model = c.Model,
                                                                        TravelledDistance = c.TravelledDistance,
                                                                        Parts = c.PartCars.Select(p => new ExportPartDto 
                                                                        {
                                                                            Name = p.Part.Name,
                                                                            Price = p.Part.Price,
                                                                        })
                                                                        .OrderByDescending(p => p.Price)
                                                                        .ToArray()
                                                                   })
                                                                   .OrderByDescending(c => c.TravelledDistance)
                                                                   .ThenBy(c => c.Model)
                                                                   .Take(5)
                                                                   .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarPartDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, carParts, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 18 ---- EXPORT TOTAL SALES BY CUSTOMER -----------------------
        //TODO MEMORY LIMIT JUDGE
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportCustomerTotalSalesDto[] customers = context.Customers
                                                             .Select(c => new ExportCustomerTotalSalesDto
                                                             {
                                                                 FullName = c.Name,
                                                                 BoughtCars = c.Sales.Count,
                                                                 SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(ss => ss.Part.Price))
                                                             })
                                                             .OrderByDescending(c => c.SpentMoney)
                                                             .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomerTotalSalesDto[]), new XmlRootAttribute("customers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 19 ---- EXPORT SALES WITH APPLIED DISCOUNT -------------------
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //TODO WRONG OUTPUT PROBABLY ON DISCOUNT CALCULATIONS
            ExportSaleDiscountDto[] sales = context.Sales.Select(s => new ExportSaleDiscountDto
            {
                Car = new ExportCarInSaleDto
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance,
                },
                Discount = s.Discount,
                CustomerName = s.Customer.Name,
                Price = s.Car.PartCars.Sum(c => c.Part.Price),
                PriceWithDiscount = (s.Car.PartCars.Sum(c => c.Part.Price) - s.Discount),   //WRONG OUTPUT PROBABLY ON DISCOUNT CALCULATIONS
            })
            .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSaleDiscountDto[]), new XmlRootAttribute("sales"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, sales, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}