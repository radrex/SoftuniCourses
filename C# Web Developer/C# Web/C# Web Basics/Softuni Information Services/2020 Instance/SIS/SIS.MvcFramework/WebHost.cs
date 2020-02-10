namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using SIS.HTTP.Response;

    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class WebHost
    {
        public static async Task StartAsync(IMvcApplication application)
        {
            List<Route> routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);
            AutoRegisterStaticFilesRoutes(routeTable);
            AutoRegisterActionRoutes(routeTable, application);

            Console.WriteLine("Registered routes:");
            foreach (Route route in routeTable)
            {
                Console.WriteLine(route);
            }

            Console.WriteLine();
            Console.WriteLine("Requests:");

            HttpServer httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        private static void AutoRegisterStaticFilesRoutes(List<Route> routeTable)
        {
            string[] staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);
            foreach (string staticFile in staticFiles)
            {
                string path = staticFile.Replace("wwwroot", string.Empty).Replace("\\", "/");
                routeTable.Add(new Route(HttpMethodType.Get, path, (request) =>
                {
                    FileInfo fileInfo = new FileInfo(staticFile);
                    var contentType = fileInfo.Extension switch
                    {
                        ".css" => "text/css",
                        ".html" => "text/html",
                        ".js" => "text/javascript",
                        ".ico" => "image/x-icon",
                        ".jpg" => "image/jpeg",
                        ".jpeg" => "image/jpeg",
                        ".png" => "image/png",
                        ".gif" => "image/gif",
                        _ => "text/plain",
                    };

                    return new FileResponse(File.ReadAllBytes(staticFile), contentType);
                }));
            }
        }
        private static void AutoRegisterActionRoutes(List<Route> routeTable, IMvcApplication application)
        {
            var types = application.GetType()
                                   .Assembly
                                   .GetTypes()
                                   .Where(type => type.IsSubclassOf(typeof(Controller)) && !type.IsAbstract);

            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
                var methods = type.GetMethods().Where(x => !x.IsSpecialName && !x.IsConstructor && x.IsPublic && x.DeclaringType == type);
                foreach (var method in methods)
                {
                    string url = "/" + type.Name.Replace("Controller", string.Empty) + "/" + method.Name;
                    HttpMethodAttribute attribute = method.GetCustomAttributes()
                                                          .FirstOrDefault(x => x.GetType().IsSubclassOf(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                    HttpMethodType httpActionType = HttpMethodType.Get;
                    if (attribute != null)
                    {
                        httpActionType = attribute.Type;
                        if (attribute.Url != null)
                        {
                            url = attribute.Url;
                        }
                    }

                    routeTable.Add(new Route(httpActionType, url, (request) =>
                    {
                        Controller controller = Activator.CreateInstance(type) as Controller;
                        controller.Request = request;
                        HttpResponse response = method.Invoke(controller, new object[] { }) as HttpResponse;
                        return response;
                    }));

                    Console.WriteLine("    " + url);
                }
            }
        }
    }
}
