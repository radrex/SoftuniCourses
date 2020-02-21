namespace IRunes
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;

    using IRunes.Data;
    using IRunes.Services.Users;
    using IRunes.Services.Albums;
    using IRunes.Services.Tracks;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IAlbumsService, AlbumsService>();
            serviceCollection.Add<ITracksService, TracksService>();
        }
    }
}
