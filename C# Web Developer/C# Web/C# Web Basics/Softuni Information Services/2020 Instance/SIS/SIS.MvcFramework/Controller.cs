namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using SIS.HTTP.Response;

    using System.IO;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected HttpResponse View([CallerMemberName] string viewName = null)
        {
            string layout = File.ReadAllText("Views/Shared/_Layout.html");
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);

            string html = File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");

            // Replacing the RenderBody() in _Layout.html with the html body
            string bodyWithLayout = layout.Replace("@RenderBody()", html);

            return new HtmlResponse(bodyWithLayout);
        }
    }
}
