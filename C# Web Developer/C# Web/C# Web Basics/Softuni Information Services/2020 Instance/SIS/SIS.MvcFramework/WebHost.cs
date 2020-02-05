namespace SIS.MvcFramework
{
    using SIS.HTTP;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class WebHost
    {
        public static async Task StartAsync(IMvcApplication application)
        {
            List<Route> routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);

            HttpServer httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }
    }
}
