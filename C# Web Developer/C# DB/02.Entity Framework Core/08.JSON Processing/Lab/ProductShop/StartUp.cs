using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>()); // FOR TASK 08 ---- EXPORT USERS AND PRODUCTS

            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();  // Comment after initial create
                //db.Database.EnsureCreated();  // Comment after initial create

            //--------------------------------------------------------------------//
            //                            IMPORT DATA                             //
            //--------------------------------------------------------------------//

                //---- TASK 01 ---- IMPORT USERS ---------------------------------------
                /*
                    string jsonText = File.ReadAllText("../../../Datasets/users.json");
                    string result = ImportUsers(db, jsonText);
                    Console.WriteLine(result);
                */

                //---- TASK 02 ---- IMPORT PRODUCTS ------------------------------------
                /* 
                    string jsonText = File.ReadAllText("../../../Datasets/products.json");
                    string result = ImportProducts(db, jsonText);
                    Console.WriteLine(result);
                */

                //---- TASK 03 ---- IMPORT CATEGORIES ----------------------------------
                /*
                    string jsonText = File.ReadAllText("../../../Datasets/categories.json");
                    string result = ImportCategories(db, jsonText);
                    Console.WriteLine(result);
                */

                //---- TASK 04 ---- IMPORT CATEGORIES AND PRODUCTS ---------------------
                /*
                    string jsonText = File.ReadAllText("../../../Datasets/categories-products.json");
                    string result = ImportCategoryProducts(db, jsonText);
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
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
        //------------------- TASK 02 ---- IMPORT PRODUCTS --------------------------------------
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        //------------------- TASK 03 ---- IMPORT CATEGORIES ------------------------------------
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                                               .Where(c => c.Name != null)
                                               .ToArray();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Length}";
        }
        //------------------- TASK 04 ---- IMPORT CATEGORIES AND PRODUCTS -----------------------
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            //var validCategoryIds = context.Categories
            //                              .Select(c => c.Id)
            //                              .ToHashSet();

            //var validProductIds = context.Products
            //                             .Select(p => p.Id)
            //                             .ToHashSet();

            //CategoryProduct[] categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            //var validEntities = new List<CategoryProduct>();

            //foreach (var categoryProduct in categoriesProducts)
            //{
            //    bool isValid = validCategoryIds.Contains(categoryProduct.CategoryId) &&
            //                   validProductIds.Contains(categoryProduct.ProductId);
            //    if (isValid)
            //    {
            //        validEntities.Add(categoryProduct);
            //    }
            //}

            //context.CategoryProducts.AddRange(validEntities);
            //context.SaveChanges();

            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            
            return $"Successfully imported {categoryProducts.Length}";
        }
        //------------------- TASK 05 ---- EXPORT PRODUCTS IN RANGE -----------------------------
        public static string GetProductsInRange(ProductShopContext context)
        {
            //------------- FIRST WAY, BUT PROPERTY NAME CONVENTION IS VIOLATED IN THE ANON OBJ -------------
            //var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
            //                               .OrderBy(p => p.Price)
            //                               .Select(p => new
            //                               {
            //                                   name = p.Name,
            //                                   price = p.Price,
            //                                   seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
            //                               })
            //                               .ToArray();
            //string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            //return json;

            //------------- SECOND WAY, WITH CONTRACT RESOLVER, PROPERTY NAME CONVENTION IS SATISFIED -------------
            //var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
            //                               .OrderBy(p => p.Price)
            //                               .Select(p => new
            //                               {
            //                                   Name = p.Name,
            //                                   Price = p.Price,
            //                                   Seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
            //                               })
            //                               .ToArray();

            //var resolver = new DefaultContractResolver()
            //{
            //    NamingStrategy = new CamelCaseNamingStrategy()
            //};

            //string json = JsonConvert.SerializeObject(products, new JsonSerializerSettings() { 
            //                                                                                    ContractResolver = resolver, 
            //                                                                                    Formatting = Formatting.Indented
            //                                                                                 });
            //return json;

            //------------- THIRD WAY, WITH DTO -------------
            ProductDto[] products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                                                    .Select(p => new ProductDto
                                                    {
                                                        Name = p.Name,
                                                        Price = p.Price,
                                                        Seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
                                                        //Seller = $"{p.Seller.FirstName} {p.Seller.LastName}".Trim(), // judge doesn't accept trimmed values
                                                        //Seller = p.Seller.FirstName == null ? p.Seller.LastName : $"{p.Seller.FirstName} {p.Seller.LastName}"
                                                    })
                                                    .OrderBy(p => p.Price)
                                                    .ToArray();

            //---- We can use [JsonProperty(PropertyName="name")] on DTO property instead of the ContractResolver above
            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(products, new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented
            });

            return json;
        }
        //------------------- TASK 06 ---- EXPORT SOLD PRODUCTS ---------------------------------
        public static string GetSoldProducts(ProductShopContext context)
        {
            UserSoldProductsDto[] usersSoldProducts = context.Users.Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                                                                   .OrderBy(u => u.LastName)
                                                                   .ThenBy(u => u.FirstName)
                                                                   .Select(u => new UserSoldProductsDto
                                                                   {
                                                                       FirstName = u.FirstName,
                                                                       LastName = u.LastName,
                                                                       SoldProducts = u.ProductsSold.Where(b => b.Buyer != null)
                                                                                                    .Select(b => new BuyerProductsDto
                                                                                                    {
                                                                                                        Name = b.Name,
                                                                                                        Price = b.Price,
                                                                                                        BuyerFirstName = b.Buyer.FirstName,
                                                                                                        BuyerLastName = b.Buyer.LastName,
                                                                                                    })
                                                                                                    .ToArray()
                                                                   })
                                                                   .ToArray();
            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(usersSoldProducts, new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented
            });

            return json;
        }
        //------------------- TASK 07 ---- EXPORT CATEGORIES BY PRODUCTS COUNT ------------------
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoryByProducts = context.Categories.OrderByDescending(c => c.CategoryProducts.Count)
                                                       .Select(c => new
                                                       {
                                                           Category = c.Name,
                                                           ProductsCount = c.CategoryProducts.Count(),
                                                           AveragePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):F2}",
                                                           TotalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price)}",
                                                       })
                                                       .ToArray();
            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(categoryByProducts, new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented
            });
            return json;
        }
        //------------------- TASK 08 ---- EXPORT USERS AND PRODUCTS ----------------------------
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //--------------------------------- WITH ANONYMOUS OBJECTS -----------------------------------
            //var filteredUsers = context.Users.Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
            //                                 .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
            //                                 .Select(u => new
            //                                 {
            //                                     FirstName = u.FirstName,
            //                                     LastName = u.LastName,
            //                                     Age = u.Age,
            //                                     SoldProducts = new 
            //                                     {
            //                                        Count = u.ProductsSold.Count(ps => ps.Buyer != null),
            //                                        Products = u.ProductsSold.Where(ps => ps.Buyer != null)
            //                                                                 .Select(ps => new 
            //                                                                 {
            //                                                                    Name = ps.Name,
            //                                                                    Price = ps.Price,
            //                                                                 })
            //                                                                 .ToArray()
            //                                     }
            //                                 })
            //                                 .ToArray();
            //var result = new
            //{
            //    UsersCount = filteredUsers.Length,
            //    Users = filteredUsers,
            //};

            //var resolver = new DefaultContractResolver()
            //{
            //    NamingStrategy = new CamelCaseNamingStrategy()
            //};

            //string json = JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            //{
            //    ContractResolver = resolver,
            //    Formatting = Formatting.Indented,
            //    NullValueHandling = NullValueHandling.Ignore,
            //});
            //return json;

            //--------------------------------- WITH DTO's AND AUTOMAPPER -----------------------------------
            var users = context.Users.Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                                     .ProjectTo<UserDetailsDto>()
                                     .OrderByDescending(u => u.SoldProducts.Count)
                                     .ToArray();

            var userOutput = new UserInfoDto()
            {
                UsersCount = users.Length,
                Users = users,
            };

            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(userOutput, new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });
            return json;
        }
    }
}