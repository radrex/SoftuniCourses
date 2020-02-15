namespace SulsApp
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Database.Migrate();
        }
    }
}
