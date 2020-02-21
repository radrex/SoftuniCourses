namespace IRunes.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using IRunes.Services.Users;
    using IRunes.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        //-------------------- INDEX --------------------
        [HttpGet("/")]  // without this the path will be /Home/Index
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                HomeViewModel viewModel = new HomeViewModel();
                viewModel.Username = this.usersService.GetUsername(this.User);

                return this.View(viewModel, "/Home");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFullPage()
        {
            return this.Index();
        }
    }
}
