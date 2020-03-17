namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string ImageUrl)>
            {
                ("Sport", "https://i1.actualno.com/actualno_2013/upload/news/2019/12/16/0282751001576489149_1442140_920x517.webp"),
                ("Coronavirus", "https://www.cdc.gov/coronavirus/2019-ncov/images/2019-coronavirus.png"),
                ("News", "https://www.northampton.ac.uk/wp-content/uploads/2018/11/news.jpg"),
                ("Music", "https://cdn6.aptoide.com/imgs/2/9/3/2939f9cb2c9ce858ab299e3675b682d0.png"),
                ("Programming", "https://www.goodcore.co.uk/blog/wp-content/uploads/2019/08/coding-vs-programming-2-1024x439.jpg"),
                ("Cats", "https://wired.me/wp-content/uploads/2020/01/Science_Cats.jpg"),
                ("Dogs", "https://media.gq.com/photos/5e457ed23367520008ec8192/master/w_1600%2Cc_limit/AP_20043149563587.jpg"),
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Name,
                    Title = category.Name,
                    ImageUrl = category.ImageUrl,
                });
            }
        }
    }
}
