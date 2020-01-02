namespace PetStore.Services.Implementations
{
    using Data;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        //--------------- Fields ----------------
        private readonly PetStoreDbContext context;

        //------------ Constructors -------------
        public CategoryService(PetStoreDbContext context)
        {
            this.context = context;
        }

        //-------------- Methods ----------------
        public bool Exists(int categoryId) => this.context.Categories.Any(c => c.Id == categoryId);

    }
}
