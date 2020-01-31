namespace DemoApp
{
    using SIS.HTTP;
    using SIS.HTTP.Response;

    using System.IO;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class Program
    {
        public static async Task Main()
        {
            List<Route> routeTable = new List<Route>();
            routeTable.Add(new Route(HttpMethodType.Get, "/", Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/users/login", Login));
            routeTable.Add(new Route(HttpMethodType.Post, "/users/login", DoLogin));
            routeTable.Add(new Route(HttpMethodType.Get, "/contact", Contact));
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));


            IHttpServer httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        /// <summary>
        /// Returns the requested <see cref="HtmlResponse"/> for the Index page.
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>HTML Response</returns>
        public static HttpResponse Index(HttpRequest request)
        {
            string username = request.SessionData.ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";
            return new HtmlResponse($"<h1>Home page. Hello {username}</h1><img src='/images/img.jpeg' /><a href='/users/login/>Go to login</a>'");
        }

        /// <summary>
        /// Returns the requested <see cref="HtmlResponse"/> for the Login page.
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>HTML Response</returns>
        public static HttpResponse Login(HttpRequest request)
        {
            request.SessionData["Username"] = "Pesho";
            return new HtmlResponse("<h1>login page</h1>");
            // When making HTTP REQUEST GET for login page (just to open it)
        }

        /// <summary>
        /// Returns the requested <see cref="HtmlResponse"/> for the DoLogin page.
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>HTML Response</returns>
        public static HttpResponse DoLogin(HttpRequest request)
        {
            return new HtmlResponse("<h1>login page form</h1>");
            // When making HTTP REQUEST POST for login page (sending information)
        }

        /// <summary>
        /// Returns the requested <see cref="HtmlResponse"/> for the Contact page.
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>HTML Response</returns>
        public static HttpResponse Contact(HttpRequest request)
        {
            return new HtmlResponse("<h1>contact</h1>");
        }

        /// <summary>
        /// Returns the requested <see cref="FileResponse"/> for the favicon.
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>File Response</returns>
        public static HttpResponse FavIcon(HttpRequest request)
        {
            //TODO: Add MIME Types enum ... image/x-icon ...
            byte[] byteContent = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(byteContent, "image/x-icon");
        }

        // headers => html table (list of all headers)
    }
}
