namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Services.Models.Food;

    using System;
    using System.Linq;

    public class FoodService : IFoodService
    {
        //------------------ Fields -------------------
        private readonly PetStoreDbContext context;
        private readonly IUserService userService;

        //--------------- Constructors ----------------
        public FoodService(PetStoreDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        //----------------- Methods -------------------
        public void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expirationData, int brandId, int categoryId)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            // Profit should be in range 0-500%
            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException("Profit must be higher than zero and lowe than 500%");
            }

            Food food = new Food()
            {
                Name = name,
                Weight = weight,
                DistributorPrice = price,
                Price = price + (price * (decimal)profit),
                ExpirationDate = expirationData,
                BrandId = brandId,
                CategoryId = categoryId,
            };

            this.context.Foods.Add(food);
            this.context.SaveChanges();
        }

        public void BuyFromDistributor(AddingFoodServiceModel model)
        {
            if (String.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            // Profit should be in range 0-500%
            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException("Profit must be higher than zero and lowe than 500%");
            }

            Food food = new Food()
            {
                Name = model.Name,
                Weight = model.Weight,
                DistributorPrice = model.Price,
                Price = model.Price + (model.Price * (decimal)model.Profit),
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
            };

            this.context.Foods.Add(food);
            this.context.SaveChanges();
        }

        public bool Exists(int foodId) => this.context.Foods.Any(f => f.Id == foodId);

        public void SellFoodToUser(int foodId, int userId)
        {
            if (!this.Exists(foodId))
            {
                throw new ArgumentException("There is no such food with given id in the database!");
            }

            if (!this.userService.Exists(userId))
            {
                throw new ArgumentException("There is no such user with given id in the database!");
            }

            Order order = new Order()
            {
                PurchaseDate = DateTime.Now,
                Status = OrderStatus.Done,
                UserId = userId,
            };

            FoodOrder foodOrder = new FoodOrder()
            {
                FoodId = foodId,
                Order = order,
            };

            this.context.Orders.Add(order);
            this.context.FoodOrders.Add(foodOrder);
            this.context.SaveChanges();
        }
    }
}
