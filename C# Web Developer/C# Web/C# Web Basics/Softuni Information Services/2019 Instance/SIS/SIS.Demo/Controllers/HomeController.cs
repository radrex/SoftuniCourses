namespace SIS.Demo.Controllers
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Home(IHttpRequest request)
        {
            //TODO: Cookies not loading in browser, but instead shows on html page.
            return this.View();
        }
    }
}
