namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }
    }
}
