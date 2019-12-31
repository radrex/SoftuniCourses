namespace PetStore
{
    using Data;
    using Services;
    using Services.Implementations;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new PetStoreDbContext();

            //IBrandService brandService = new BrandService(context);
            //brandService.Create("Purrina");
            //var brandWithToys = brandService.FindByIdWithToys(1);

            //brandService.Create("Whiskas");
            //add Category 1 - Cat manually

            //IFoodService foodService = new FoodService(context);
            //foodService.BuyFromDistributor("Cat food", 0.350, 1.10M, 0.3, DateTime.Now, 2, 1);

            //IToyService toyService = new ToyService(context);
            //toyService.BuyFromDistributor("Ball", null, 3.50M, 0.3, 1, 1);

            //IUserService userService = new UserService(context);
            //IFoodService foodService = new FoodService(context, userService);

            //userService.Register("Pesho", "pesho123@mail.com");
            //foodService.SellFoodToUser(1, 1);

            //IUserService userService = new UserService(context);
            //IToyService toyService = new ToyService(context, userService);
            //toyService.SellToyToUser(1, 1);

            //IBreedService breedService = new BreedService(context);
            //breedService.Add("Persian");

            //IBreedService breedService = new BreedService(context);
            //ICategoryService categoryService = new CategoryService(context);
            //IUserService userService = new UserService(context);
            //IPetService petService = new PetService(context, breedService, categoryService, userService);
            //petService.BuyPet(Data.Models.Enums.Gender.Male, DateTime.Now, 0m, null, 1, 1);
            //petService.SellPet(1, 1);
        }
    }
}
