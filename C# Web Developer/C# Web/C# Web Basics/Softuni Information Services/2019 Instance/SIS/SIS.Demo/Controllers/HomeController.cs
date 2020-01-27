namespace SIS.Demo.Controllers
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Home(IHttpRequest request)
        {
            return this.View();

            //string content = "<h1>Hello, World!</h1>";
            //return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}
