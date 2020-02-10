namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using SIS.HTTP.Response;

    using System.IO;
    using System.Text;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;

    public abstract class Controller
    {
        protected HttpResponse View<T>(T viewModel = null, [CallerMemberName]string viewName = null)
            where T : class
        {
            string typeName = this.GetType().Name/*.Replace("Controller", string.Empty)*/;
            string controllerName = typeName.Substring(0, typeName.Length - 10);
            string viewPath = "Views/" + controllerName + "/" + viewName + ".html";
            return this.ViewByName<T>(viewPath, viewModel);
        }

        protected HttpResponse View([CallerMemberName] string viewName = null)
        {
            return this.View<object>(null, viewName);
        }

        public HttpRequest Request { get; set; }

        protected HttpResponse Error(string error)
        {
            return this.ViewByName<ErrorViewModel>("Views/Shared/Error.html", new ErrorViewModel { Error = error });
        }

        protected HttpResponse Redirect(string url)
        {
            return new RedirectResponse(url);
        }

        protected string Hash(string input)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        private HttpResponse ViewByName<T>(string viewPath, object viewModel)
        {
            IViewEngine viewEngine = new ViewEngine();
            string html = File.ReadAllText(viewPath);
            html = viewEngine.GetHtml(html, viewModel); // viewEngine.GetHtml returns the final parsed html

            string layout = File.ReadAllText("Views/Shared/_Layout.html");
            string bodyWithLayout = layout.Replace("@RenderBody()", html); // Replacing the RenderBody() in _Layout.html with the html body
            bodyWithLayout = viewEngine.GetHtml(bodyWithLayout, viewModel); // viewEngine.GetHtml returns the final parsed html for the layout

            return new HtmlResponse(bodyWithLayout);
        }
    }
}
