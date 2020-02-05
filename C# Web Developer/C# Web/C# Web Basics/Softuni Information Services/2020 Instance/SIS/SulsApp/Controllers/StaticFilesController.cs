namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SIS.HTTP.Response;

    using System.IO;

    public class StaticFilesController : Controller
    {
        public HttpResponse Bootstrap(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/bootstrap.min.css"), "text/css");
        }

        public HttpResponse Site(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/site.css"), "text/css");
        }

        public HttpResponse Reset(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/reset-css.css"), "text/css");
        }
    }
}
