namespace PetStore.Services
{
    using Services.Models.Food;

    using System;

    public interface IFoodService
    {
        void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expirationData, int brandId, int categoryId);
        void BuyFromDistributor(AddingFoodServiceModel model);
        void SellFoodToUser(int foodId, int userId);
        bool Exists(int foodId);
    }
}
