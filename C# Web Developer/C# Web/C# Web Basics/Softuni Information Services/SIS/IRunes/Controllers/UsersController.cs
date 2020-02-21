namespace IRunes.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using IRunes.Services.Users;
    using IRunes.ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        //-------------------- LOGIN --------------------
        // /Users/Login
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel inputModel)
        {
            string userId = this.usersService.GetUserId(inputModel.Username, inputModel.Password);
            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Home/Index");
            }

            return this.Redirect("/Users/Login");
        }

        //------------------- REGISTER ------------------
        // /Users/Register
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (inputModel.Username.Length < 4 || inputModel.Username.Length > 10)
            {
                //return this.View();
                return this.Error("Username must be at least 4 characters and at most 10");
            }

            if (inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                //return this.View();
                return this.Error("Password must be at least 6 characters and at most 20");
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Error("Password should match.");
                //return this.View();
            }

            if (string.IsNullOrWhiteSpace(inputModel.Email))
            {
                //return this.View();
                return this.Error("Email cannot be empty!");
            }

            if (this.usersService.UsernameExists(inputModel.Username))
            {
                return this.Error("Username already in use.");
                //return this.View();
            }

            if (this.usersService.EmailExists(inputModel.Email))
            {
                return this.Error("Email already in use.");
                //return this.View();
            }

            this.usersService.RegisterUser(inputModel.Username, inputModel.Password, inputModel.Email);
            return this.Redirect("/Users/Login");
        }

        //-------------------- LOGOUT -------------------
        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/Home/Index");
        }
    }
}
