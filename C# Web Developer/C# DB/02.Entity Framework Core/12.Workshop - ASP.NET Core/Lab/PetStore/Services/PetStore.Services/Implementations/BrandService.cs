namespace PetStore.Services.Implementations
{
    using Models.Brand;
    using Models.Toy;

    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Data.Models.DataValidation;

    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class BrandService : IBrandService
    {
        //----------------- Fields ------------------
        private readonly PetStoreDbContext context;

        //-------------- Constructors ---------------
        public BrandService(PetStoreDbContext context) => this.context = context;

        //---------------- Methods ------------------
        public int Create(string name)
        {
            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Brand name cannot be more than {DataValidation.NameMaxLength} characters.");
            }

            if (this.context.Brands.Any(b => b.Name == name))
            {
                throw new InvalidOperationException($"Brand name {name} already exists.");
            }

            Brand brand = new Brand
            {
                Name = name,
            };

            this.context.Brands.Add(brand);
            this.context.SaveChanges();

            return brand.Id;
        }

        public IEnumerable<BrandListingServiceModel> SearchByName(string name) => this.context.Brands
                                                                                              .Where(b => b.Name.ToLower().Contains(name.ToLower()))
                                                                                              .Select(b => new BrandListingServiceModel
                                                                                              {
                                                                                                  Id = b.Id,
                                                                                                  Name = b.Name,
                                                                                              })
                                                                                              .ToList();

        public BrandWithToysServiceModel FindByIdWithToys(int id) => this.context.Brands
                                                                                 .Where(b => b.Id == id)
                                                                                 .Select(b => new BrandWithToysServiceModel
                                                                                 {
                                                                                     Name = b.Name,
                                                                                     Toys = b.Toys.Select(t => new ToyListingServiceModel 
                                                                                     {
                                                                                        Id = t.Id,
                                                                                        Name = t.Name,
                                                                                        Price = t.Price,
                                                                                        TotalOrders = t.Orders.Count,
                                                                                     })
                                                                                 })
                                                                                 .FirstOrDefault();
    }
}
