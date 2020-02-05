namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using System.Collections.Generic;

    public interface IMvcApplication
    {
        void Configure(IList<Route> routeTable);
        void ConfigureServices();
    }
}
