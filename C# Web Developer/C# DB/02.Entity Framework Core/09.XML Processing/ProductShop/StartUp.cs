using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();  // Comment after initial create
                //db.Database.EnsureCreated();  // Comment after initial create

            //--------------------------------------------------------------------//
            //                            IMPORT DATA                             //
            //--------------------------------------------------------------------//

                //---- TASK 01 ---- IMPORT USERS ---------------------------------------
                /*
                    string xmlText = File.ReadAllText("../../../Datasets/users.xml");
                    string result = ImportUsers(db, xmlText);
                    Console.WriteLine(result);
                */

                //---- TASK 02 ---- IMPORT PRODUCTS ------------------------------------
                /*
                   string xmlText = File.ReadAllText("../../../Datasets/products.xml");
                   string result = ImportProducts(db, xmlText);
                   Console.WriteLine(result);
                */

                //---- TASK 03 ---- IMPORT CATEGORIES ----------------------------------
                /*
                    string xmlText = File.ReadAllText("../../../Datasets/categories.xml");
                    string result = ImportCategories(db, xmlText);
                    Console.WriteLine(result);
                */

                //---- TASK 04 ---- IMPORT CATEGORIES AND PRODUCTS ---------------------
                /*
                    string xmlText = File.ReadAllText("../../../Datasets/categories-products.xml");
                    string result = ImportCategoryProducts(db, xmlText);
                    Console.WriteLine(result);
                */

            //--------------------------------------------------------------------//
            //                            EXPORT DATA                             //
            //--------------------------------------------------------------------//

                //---- TASK 05 ---- EXPORT PRODUCTS IN RANGE ---------------------------
                /*
                    string result = GetProductsInRange(db);
                    Console.WriteLine(result);
                */

                //---- TASK 06 ---- EXPORT SOLD PRODUCTS -------------------------------
                /*
                    string result = GetSoldProducts(db);
                    Console.WriteLine(result);
                */

                //---- TASK 07 ---- EXPORT CATEGORIES BY PRODUCTS COUNT ----------------
                /*
                    string result = GetCategoriesByProductsCount(db);
                    Console.WriteLine(result);
                */

                //---- TASK 08 ---- EXPORT USERS AND PRODUCTS --------------------------
                string result = GetUsersWithProducts(db);
                Console.WriteLine(result);
            }
        }

        //------------------- TASK 01 ---- IMPORT USERS -----------------------------------------
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            //-------------------- WITH AUTOMAPPER AND DTO --------------------
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            //ImportUserDto[] userDtos;
            //using (var reader = new StringReader(inputXml))
            //{
            //    userDtos = xmlSerializer.Deserialize(reader) as ImportUserDto[];
            //}

            //User[] users = Mapper.Map<User[]>(userDtos);

            //context.Users.AddRange(users);
            //context.SaveChanges();

            //return $"Successfully imported {users.Length}";

            //-------------------- WITH MANUAL MAPPING --------------------
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            ImportUserDto[] userDtos;
            using (var reader = new StringReader(inputXml))
            {
                userDtos = (xmlSerializer.Deserialize(reader) as ImportUserDto[]);
            }

            List<User> users = new List<User>();
            foreach (ImportUserDto dto in userDtos)
            {
                User user = new User()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                };
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        //------------------- TASK 02 ---- IMPORT PRODUCTS --------------------------------------
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            //-------------------- WITH AUTOMAPPER AND DTO --------------------
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            //ImportProductDto[] productDtos;
            //using (var reader = new StringReader(inputXml))
            //{
            //    productDtos = xmlSerializer.Deserialize(reader) as ImportProductDto[];
            //}

            //Product[] products = Mapper.Map<Product[]>(productDtos);

            //context.Products.AddRange(products);
            //context.SaveChanges();

            //return $"Successfully imported {products.Length}";

            //-------------------- WITH MANUAL MAPPING --------------------
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            ImportProductDto[] productDtos;
            using (var reader = new StringReader(inputXml))
            {
                productDtos = (xmlSerializer.Deserialize(reader) as ImportProductDto[]);
            }

            List<Product> products = new List<Product>();
            foreach (ImportProductDto dto in productDtos)
            {
                Product product = new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId,
                };
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
        //------------------- TASK 03 ---- IMPORT CATEGORIES ------------------------------------
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            //-------------------- WITH AUTOMAPPER AND DTO --------------------
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            //ImportCategoryDto[] categoryDtos;
            //using (var reader = new StringReader(inputXml))
            //{
            //    categoryDtos = (xmlSerializer.Deserialize(reader) as ImportCategoryDto[]).Where(c => c.Name != null)
            //                                                                             .ToArray();
            //}

            //Category[] categories = Mapper.Map<Category[]>(categoryDtos);

            //context.Categories.AddRange(categories);
            //context.SaveChanges();

            //return $"Successfully imported {categories.Length}";

            //-------------------- WITH MANUAL MAPPING --------------------
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            ImportCategoryDto[] categoryDtos;
            using (var reader = new StringReader(inputXml))
            {
                categoryDtos = (xmlSerializer.Deserialize(reader) as ImportCategoryDto[]).Where(c => c.Name != null)
                                                                                         .ToArray();
            }

            List<Category> categories = new List<Category>();
            foreach (ImportCategoryDto dto in categoryDtos)
            {
                Category category = new Category()
                {
                    Name = dto.Name,
                };
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        //------------------- TASK 04 ---- IMPORT CATEGORIES AND PRODUCTS -----------------------
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            //-------------------- WITH AUTOMAPPER AND DTO --------------------
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            //ImportCategoryProductDto[] categoryProductDtos;
            //using (var reader = new StringReader(inputXml))
            //{
            //    categoryProductDtos = (xmlSerializer.Deserialize(reader) as ImportCategoryProductDto[]);
            //}

            //CategoryProduct[] categoriesProducts = Mapper.Map<CategoryProduct[]>(categoryProductDtos);

            //context.CategoryProducts.AddRange(categoriesProducts);
            //context.SaveChanges();

            //return $"Successfully imported {categoriesProducts.Length}";

            //-------------------- WITH MANUAL MAPPING --------------------
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            ImportCategoryProductDto[] categoryProductDtos;
            using (var reader = new StringReader(inputXml))
            {
                categoryProductDtos = (xmlSerializer.Deserialize(reader) as ImportCategoryProductDto[]);
            }

            List<CategoryProduct> categoriesProducts = new List<CategoryProduct>();
            foreach (ImportCategoryProductDto dto in categoryProductDtos)
            {
                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId,
                };
                categoriesProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }
        //------------------- TASK 05 ---- EXPORT PRODUCTS IN RANGE -----------------------------
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductInRangeDto[] products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                                                                 .OrderBy(p => p.Price)
                                                                 .Select(p => new ExportProductInRangeDto
                                                                 {
                                                                     Name = p.Name,
                                                                     Price = p.Price,
                                                                     Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName,
                                                                 })
                                                                 .Take(10)
                                                                 .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));
            //var namespaces = new XmlSerializerNamespaces(new []
            //{
            //    new XmlQualifiedName("","")
            //});

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, products, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 06 ---- EXPORT SOLD PRODUCTS ---------------------------------
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUserSoldProductDto[] users = context.Users.Where(u => u.ProductsSold.Any())
                                                            .OrderBy(u => u.LastName)
                                                            .ThenBy(u => u.FirstName)
                                                            .Select(u => new ExportUserSoldProductDto
                                                            {
                                                                FirstName = u.FirstName,
                                                                LastName = u.LastName,
                                                                SoldProducts = u.ProductsSold.Select(p => new ExportSoldProductDto
                                                                                                          {
                                                                                                              Name = p.Name,
                                                                                                              Price = p.Price,
                                                                                                          })
                                                                                                          .ToArray()
                                                            })
                                                            .Take(5)
                                                            .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserSoldProductDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, users, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 07 ---- EXPORT CATEGORIES BY PRODUCTS COUNT ------------------
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoryByProductCount[] categories = context.Categories.Select(c => new ExportCategoryByProductCount
                                                                                       {
                                                                                           Name = c.Name,
                                                                                           Count = c.CategoryProducts.Count,
                                                                                           AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                                                                                           TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price),
                                                                                       })
                                                                                       .OrderByDescending(c => c.Count)
                                                                                       .ThenBy(c => c.TotalRevenue)
                                                                                       .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoryByProductCount[]), new XmlRootAttribute("Categories"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, categories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
        //------------------- TASK 08 ---- EXPORT USERS AND PRODUCTS ----------------------------
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var filteredUsers = context.Users.Where(u => u.ProductsSold.Any())
                                             .OrderByDescending(u => u.ProductsSold.Count)
                                             .Select(u => new ExportUsersAndProductsDto
                                             {
                                                 FirstName = u.FirstName,
                                                 LastName = u.LastName,
                                                 Age = u.Age,
                                                 SoldProducts = new SoldProductDto
                                                 {
                                                     Count = u.ProductsSold.Count,
                                                     Products = u.ProductsSold.Select(ps => new ProductDto
                                                                                            {
                                                                                                Name = ps.Name,
                                                                                                Price = ps.Price,
                                                                                            })
                                                                                            .OrderByDescending(p => p.Price)
                                                                                            .ToArray()
                                                 }
                                             })
                                             .Take(10)
                                             .ToArray();

            var customExport = new ExportCustomUserProductDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                ExportUsersAndProductsDto = filteredUsers,
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomUserProductDto), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, customExport, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}