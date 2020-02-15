namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using SIS.HTTP.Response;

    using System.IO;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        public HttpRequest Request { get; set; }
        public string User => this.Request.SessionData.ContainsKey("UserId") ? this.Request.SessionData["UserId"] : null;

        protected HttpResponse View<T>(T viewModel = null, [CallerMemberName]string viewName = null)
            where T : class
        {
            string typeName = this.GetType().Name/*.Replace("Controller", string.Empty)*/;
            string controllerName = typeName.Substring(0, typeName.Length - 10);
            string viewPath = "Views/" + controllerName + "/" + viewName + ".html";
            return this.ViewByName<T>(viewPath, viewModel);
        }

        protected HttpResponse View([CallerMemberName] string viewName = null) => this.View<object>(null, viewName);
        protected HttpResponse Error(string error) => this.ViewByName<ErrorViewModel>("Views/Shared/Error.html", new ErrorViewModel { Error = error });
        protected HttpResponse Redirect(string url) => new RedirectResponse(url);
        protected bool IsUserLoggedIn() => this.User != null;
        protected void SignIn(string userId) => this.Request.SessionData["UserId"] = userId;
        protected void SignOut() => this.Request.SessionData["UserId"] = null;

        private HttpResponse ViewByName<T>(string viewPath, object viewModel)
        {
            IViewEngine viewEngine = new ViewEngine();
            string html = File.ReadAllText(viewPath);
            html = viewEngine.GetHtml(html, viewModel, this.User); // viewEngine.GetHtml returns the final parsed html

            string layout = File.ReadAllText("Views/Shared/_Layout.html");
            string bodyWithLayout = layout.Replace("@RenderBody()", html); // Replacing the RenderBody() in _Layout.html with the html body
            bodyWithLayout = viewEngine.GetHtml(bodyWithLayout, viewModel, this.User); // viewEngine.GetHtml returns the final parsed html for the layout

            return new HtmlResponse(bodyWithLayout);
        }
    }
}
