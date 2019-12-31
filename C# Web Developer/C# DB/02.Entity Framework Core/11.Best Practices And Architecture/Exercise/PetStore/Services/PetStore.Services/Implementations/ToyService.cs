namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Services.Models.Toy;

    using System;
    using System.Linq;

    public class ToyService : IToyService
    {
        //------------------- Fields --------------------
        private readonly PetStoreDbContext context;
        private readonly IUserService userService;

        //---------------- Constructors -----------------
        public ToyService(PetStoreDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        //------------------ Methods --------------------
        public void BuyFromDistributor(string name, string description, decimal distributionPrice, double profit, int brandId, int categoryId)
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

            Toy toy = new Toy()
            {
                Name = name,
                Description = description,
                DistributorPrice = distributionPrice,
                Price = distributionPrice + (distributionPrice * (decimal)profit),
                BrandId = brandId,
                CategoryId = categoryId,
            };

            this.context.Toys.Add(toy);
            this.context.SaveChanges();
        }

        public void BuyFromDistributor(AddingToyServiceModel model)
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

            Toy toy = new Toy()
            {
                Name = model.Name,
                Description = model.Description,
                DistributorPrice = model.Price,
                Price = model.Price + (model.Price * (decimal)model.Profit),
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
            };

            this.context.Toys.Add(toy);
            this.context.SaveChanges();
        }

        public bool Exists(int toyId) => this.context.Toys.Any(t => t.Id == toyId);

        public void SellToyToUser(int toyId, int userId)
        {
            if (!this.Exists(toyId))
            {
                throw new ArgumentException("There is no such toy with given id in the database!");
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

            ToyOrder toyOrder = new ToyOrder()
            {
                ToyId = toyId,
                Order = order,
            };


            this.context.Orders.Add(order);
            this.context.ToyOrders.Add(toyOrder);
            this.context.SaveChanges();
        }
    }
}
