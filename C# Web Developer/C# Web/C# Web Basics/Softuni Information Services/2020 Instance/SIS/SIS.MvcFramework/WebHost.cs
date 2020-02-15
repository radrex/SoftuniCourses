namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using SIS.HTTP.Logging;
    using SIS.HTTP.Response;

    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class WebHost
    {
        public static async Task StartAsync(IMvcApplication application)
        {
            IList<Route> routeTable = new List<Route>();

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.Add<ILogger, ConsoleLogger>();

            application.ConfigureServices(serviceCollection);
            application.Configure(routeTable);
            AutoRegisterStaticFilesRoutes(routeTable);
            AutoRegisterActionRoutes(routeTable, application, serviceCollection);

            ILogger logger = serviceCollection.CreateInstance<ILogger>();
            logger.Log("Registered routes:");
            foreach (Route route in routeTable)
            {
                logger.Log(route.ToString());
            }

            logger.Log(string.Empty);
            logger.Log("Requests:");
            HttpServer httpServer = new HttpServer(80, routeTable, logger);
            await httpServer.StartAsync();
        }

        // /{controller}/{action}/
        private static void AutoRegisterActionRoutes(IList<Route> routeTable, IMvcApplication application, IServiceCollection serviceCollection)
        {
            var controllers = application.GetType()
                                         .Assembly
                                         .GetTypes()
                                         .Where(type => type.IsSubclassOf(typeof(Controller)) && !type.IsAbstract);

            foreach (Type controller in controllers)
            {
                var actions = controller.GetMethods().Where(x => !x.IsSpecialName && !x.IsConstructor && x.IsPublic && x.DeclaringType == controller);
                foreach (var action in actions)
                {
                    string url = "/" + controller.Name.Replace("Controller", string.Empty) + "/" + action.Name;

                    HttpMethodAttribute attribute = action.GetCustomAttributes()
                                                          .FirstOrDefault(x => x.GetType()
                                                          .IsSubclassOf(typeof(HttpMethodAttribute))) as HttpMethodAttribute;

                    HttpMethodType httpActionType = HttpMethodType.Get;
                    if (attribute != null)
                    {
                        httpActionType = attribute.Type;
                        if (attribute.Url != null)
                        {
                            url = attribute.Url;
                        }
                    }

                    routeTable.Add(new Route(httpActionType, url, (request) => InvokeAction(request, serviceCollection, controller, action)));
                }
            }
        }

        private static HttpResponse InvokeAction(HttpRequest request, IServiceCollection serviceCollection, Type controllerType, MethodInfo actionMethod)
        {
            Controller controller = serviceCollection.CreateInstance(controllerType) as Controller;
            controller.Request = request;

            List<object> actionParameterValues = new List<object>();
            ParameterInfo[] actionParameters = actionMethod.GetParameters();
            foreach (ParameterInfo parameter in actionParameters)
            {
                var value = Convert.ChangeType(GetValueFromRequest(request, parameter.Name), parameter.ParameterType); // convert to primitive type

                if (value == null && parameter.ParameterType != typeof(string)) // with complex type/object
                {
                    var parameterValue = Activator.CreateInstance(parameter.ParameterType);
                    foreach (PropertyInfo property in parameter.ParameterType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        var propertyValue = GetValueFromRequest(request, property.Name);
                        property.SetValue(parameterValue, Convert.ChangeType(propertyValue, property.PropertyType));
                    }

                    actionParameterValues.Add(parameterValue);
                }
                else
                {
                    actionParameterValues.Add(value);
                }
            }

            HttpResponse response = actionMethod.Invoke(controller, actionParameterValues.ToArray()) as HttpResponse;
            return response;
        }

        private static object GetValueFromRequest(HttpRequest request, string parameterName)
        {
            object value = null;
            parameterName = parameterName.ToLower();
            if (request.QueryData.Any(x => x.Key.ToLower() == parameterName))
            {
                value = request.QueryData.FirstOrDefault(x => x.Key.ToLower() == parameterName).Value;
            }
            else if (request.FormData.Any(x => x.Key.ToLower() == parameterName))
            {
                value = request.FormData.FirstOrDefault(x => x.Key.ToLower() == parameterName).Value;
            }

            return value;
        }

        private static void AutoRegisterStaticFilesRoutes(IList<Route> routeTable)
        {
            string[] staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);
            foreach (string staticFile in staticFiles)
            {
                string path = staticFile.Replace("wwwroot", string.Empty).Replace("\\", "/");
                routeTable.Add(new Route(HttpMethodType.Get, path, (request) =>
                {
                    FileInfo fileInfo = new FileInfo(staticFile);
                    string contentType = fileInfo.Extension switch
                    {
                        ".css"  =>  "text/css",
                        ".html" =>  "text/html",
                        ".js"   =>  "text/javascript",
                        ".ico"  =>  "image/x-icon",
                        ".jpg"  =>  "image/jpeg",
                        ".jpeg" =>  "image/jpeg",
                        ".png"  =>  "image/png",
                        ".gif"  =>  "image/gif",
                        _       =>  "text/plain",
                    };

                    return new FileResponse(File.ReadAllBytes(staticFile), contentType);
                }));
            }
        }
    }
}
