namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    using Data;
    using ViewModels.Items;
    using FastFood.Models;

    public class ItemsController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public ItemsController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var categories = this.context.Categories
                                         .ProjectTo<CreateItemViewModel>(this.mapper.ConfigurationProvider)
                                         .ToList();
            return this.View(categories);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var item = this.mapper.Map<Item>(model);
            this.context.Items.Add(item);
            this.context.SaveChanges();
            return this.RedirectToAction("All", "Items");
        }

        public IActionResult All()
        {
            var items = this.context.Items
                            .ProjectTo<ItemsAllViewModels>(this.mapper.ConfigurationProvider)
                            .ToList();

            return this.View(items);
        }
    }
}
