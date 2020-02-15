namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SulsApp.Services;
    using SulsApp.ViewModels.Submissions;
    using System.Linq;

    public class SubmissionsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ApplicationDbContext db, ISubmissionsService submissionsService)
        {
            this.db = db;
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.db.Problems.Where(x => x.Id == id)
                                          .Select(x => new CreateFormViewModel
                                          {
                                              Name = x.Name,
                                              ProblemId = x.Id,
                                          }).FirstOrDefault();
            if (problem == null)
            {
                return this.Error("Problem not found");
            }
            return this.View(problem);

            //-------------------------- Second option ----------------------------
            //var problem = this.db.Problems.FirstOrDefault(x => x.Id == id);
            //if (problem == null)
            //{
            //    return this.Error("Problem not found");
            //}

            //var viewModel = new CreateFormViewModel
            //{
            //    Name = problem.Name,
            //    ProblemId = problem.Id,
            //};

            //return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Error("/Users/Login");
            }

            if (code == null || code.Length < 30)
            {
                return this.Error("Please provide code with at least 30 characters.");
            }

            this.submissionsService.Create(this.User, problemId, code);
            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Error("/Users/Login");
            }

            this.submissionsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
