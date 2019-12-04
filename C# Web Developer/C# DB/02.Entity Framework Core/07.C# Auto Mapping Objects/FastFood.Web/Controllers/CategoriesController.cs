namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;

    using Data;
    using ViewModels.Categories;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using FastFood.Models;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

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

            var category = this.mapper.Map<Category>(model);
            this.context.Categories.Add(category);
            this.context.SaveChanges();
            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            var categories = this.context.Categories
                                         .ProjectTo<CategoryAllViewModel>(this.mapper.ConfigurationProvider)
                                         .ToList();
            return this.View(categories);
        }
    }
}
