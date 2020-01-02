namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using PetStore.Services.Models.Pet;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PetService : IPetService
    {
        //-------------- Constants --------------
        private const int PetsPageSize = 25;

        //--------------- Fields ----------------
        private readonly PetStoreDbContext context;
        private readonly IBreedService breedService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;

        //------------ Constructors -------------
        public PetService(PetStoreDbContext context, IBreedService breedService, ICategoryService categoryService, IUserService userService)
        {
            this.context = context;
            this.breedService = breedService;
            this.categoryService = categoryService;
            this.userService = userService;
        }

        //-------------- Methods ----------------
        public IEnumerable<PetListingServiceModel> All(int page = 1) => this.context.Pets
                                                                                    .Skip((page - 1) * PetsPageSize)    // for paging
                                                                                    .Take(PetsPageSize)                 // for paging
                                                                                    .Select(p => new PetListingServiceModel
                                                                                    {
                                                                                                     Id = p.Id,
                                                                                                     Category = p.Category.Name,
                                                                                                     Price = p.Price,
                                                                                                     Breed = p.Breed.Name,
                                                                                                 })
                                                                                                 .ToList();
                                                                                                      
        public void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price of the pet cannot be less than zero!");
            }

            if (!this.breedService.Exists(breedId))
            {
                throw new ArgumentException("There is no such breed with given id in database!");
            }

            if (!this.categoryService.Exists(categoryId))
            {
                throw new ArgumentException("There is no such category with given id in database!");
            }

            Pet pet = new Pet()
            {
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Price = price,
                Description = description,
                BreedId = breedId,
                CategoryId = categoryId,
            };

            this.context.Pets.Add(pet);
            this.context.SaveChanges();
        }

        public bool Exists(int petId) => this.context.Pets.Any(p => p.Id == petId);

        public void SellPet(int petId, int userId)
        {
            if (!this.userService.Exists(userId))
            {
                throw new ArgumentException("There is no such user with given id in database!");
            }

            if (!this.Exists(petId))
            {
                throw new ArgumentException("There is no such pet with given id in database!");
            }

            Pet pet = this.context.Pets.First(p => p.Id == petId);

            Order order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId,
            };

            this.context.Orders.Add(order);
            pet.Order = order;
            this.context.SaveChanges();
        }

        public int Total() => this.context.Pets.Count();

        public PetDetailsServiceModel Details(int id) => this.context.Pets.Where(p => p.Id == id)
                                                                          .Select(p => new PetDetailsServiceModel
                                                                          {
                                                                              Id = p.Id,
                                                                              Breed = p.Breed.Name,
                                                                              Category = p.Category.Name,
                                                                              DateOfBirth = p.DateOfBirth,
                                                                              Description = p.Description,
                                                                              Gender = p.Gender,
                                                                              Price = p.Price,
                                                                          })
                                                                          .FirstOrDefault();

        public bool Delete(int id)
        {
            var pet = this.context.Pets.Find(id);
            if (pet == null)
            {
                return false;
            }

            this.context.Pets.Remove(pet);
            this.context.SaveChanges();
            return true;
        }
    }
}
