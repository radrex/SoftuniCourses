namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
    }
}
