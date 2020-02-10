namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SulsApp.ViewModels;

    using System;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            IndexViewModel viewModel = new IndexViewModel
            {
                Message = "Welcome to SULS Platform!",
                Year = DateTime.UtcNow.Year,
            };

            return this.View(viewModel);
        }
    }
}
