namespace PetStore.Services.Implementations
{
    using Data;
    using Data.Models;
    using Services.Models.Category;

    using System.Collections.Generic;
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
        public void Create(CreateCategoryServiceModel model)
        {
            Category category = new Category()
            {
                Name = model.Name,
                Description = model.Description,
            };

            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }

        public IEnumerable<AllCategoriesServiceModel> All() => this.context.Categories
                                                                           .Select(c => new AllCategoriesServiceModel
                                                                           {
                                                                               Id = c.Id,
                                                                               Name = c.Name,
                                                                               Description = c.Description,
                                                                           })
                                                                           .ToArray();
        public bool Exists(int categoryId) => this.context.Categories.Any(c => c.Id == categoryId);

        public DetailsCategoryServiceModel GetById(int id)
        {
            Category category = this.context.Categories.Find(id);

            DetailsCategoryServiceModel model = new DetailsCategoryServiceModel
            {
                Id = category?.Id,
                Name = category?.Name,
                Description = category?.Description,
            };

            return model;
        }

        public void Edit(EditCategoryServiceModel model)
        {
            Category category = this.context.Categories.Find(model.Id);

            category.Name = model.Name;
            category.Description = model.Description;

            this.context.SaveChanges();
        }

        public bool Remove(int id)
        {
            Category category = this.context.Categories.Find(id);

            if (category == null)
            {
                return false;
            }

            this.context.Categories.Remove(category);
            int deletedEntities = this.context.SaveChanges();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}
