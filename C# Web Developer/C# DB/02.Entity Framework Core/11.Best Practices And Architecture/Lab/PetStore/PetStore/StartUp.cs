namespace PetStore
{
    using PetStore.Data;
    using Services.Implementations;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using var data = new PetStoreDbContext();

            BrandService brandService = new BrandService(data);

            brandService.Create("Purrina");

            var brandWithToys = brandService.FindByIdWithToys(1);
        }
    }
}
