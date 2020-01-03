namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Web.Models.Category;
    using Services.Models.Category;
    using Services;

    using System.Linq;

    public class CategoriesController : Controller
    {
        //-------------------- Fields ---------------------
        private readonly ICategoryService categoryService;

        //----------------- Constructors ------------------
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        //------------------- Methods ---------------------
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            CreateCategoryServiceModel categoryServiceModel = new CreateCategoryServiceModel
            {
                Name = model.Name,
                Description = model.Description,
            };

            this.categoryService.Create(categoryServiceModel);

            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            CategoryListingViewModel[] categories = categoryService.All().Select(csm => new CategoryListingViewModel
                                                                         {
                                                                             Id = csm.Id,
                                                                             Name = csm.Name,
                                                                         })
                                                                         .ToArray();
            return this.View(categories);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            DetailsCategoryServiceModel category = this.categoryService.GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }

            CategoryDetailsViewModel viewModel = new CategoryDetailsViewModel
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description,
            };

            if (viewModel.Description == null)
            {
                viewModel.Description = "No description.";
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DetailsCategoryServiceModel category = this.categoryService.GetById(id);

            if (category.Name == null)
            {
                return this.BadRequest();
            }

            CategoryDetailsViewModel viewModel = new CategoryDetailsViewModel
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditInputModel model)
        {
            if (!this.categoryService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditCategoryServiceModel serviceModel = new EditCategoryServiceModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };

            this.categoryService.Edit(serviceModel);

            return this.RedirectToAction("Details", "Categories", new { id = serviceModel.Id });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            DetailsCategoryServiceModel category = this.categoryService.GetById(id);

            if (category.Name == null)
            {
                return this.BadRequest();
            }

            if (category.Description == null)
            {
                category.Description = "No description.";
            }

            CategoryDetailsViewModel model = new CategoryDetailsViewModel
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Delete(CategoryDetailsViewModel model)
        {
            bool success = this.categoryService.Remove(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home");
            }

            return this.RedirectToAction("All", "Categories");
        }
    }
}