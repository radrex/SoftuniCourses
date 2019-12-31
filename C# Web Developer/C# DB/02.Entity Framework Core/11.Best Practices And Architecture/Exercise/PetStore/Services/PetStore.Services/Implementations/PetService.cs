namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using Data.Models.Enums;

    using System;
    using System.Linq;

    public class PetService : IPetService
    {
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
    }
}
