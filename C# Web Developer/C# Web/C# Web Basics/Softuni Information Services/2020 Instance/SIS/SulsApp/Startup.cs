namespace SulsApp
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }

        public void Configure(IList<Route> routeTable)
        {

        }
    }
}
