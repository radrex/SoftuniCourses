namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SulsApp.Services;
    using SulsApp.ViewModels.Problems;
    using System.Linq;

    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ApplicationDbContext db;

        public ProblemsController(IProblemsService problemsService, ApplicationDbContext db)
        {
            this.problemsService = problemsService;
            this.db = db;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(name))
            {
                return this.Error("Invalid name");
            }

            if (points <= 0 || points > 100)
            {
                return this.Error("Points range: [1-100]");
            }

            this.problemsService.CreateProblem(name, points);
            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                this.Error("/Users/Login");
            }

            var viewModel = this.db.Problems.Where(p => p.Id == id)
                                            .Select(p => new DetailsViewModel
                                            {
                                                Name = p.Name,
                                                Problems = p.Submissions.Select(s => new ProblemDetailsSubmissionViewModel 
                                                                         {
                                                                            CreatedOn = s.CreatedOn,
                                                                            AchievedResult = s.AchievedResult,
                                                                            SubmissionId = s.Id,
                                                                            MaxPoints = p.Points,
                                                                            Username = s.User.Username,
                                                                         })
                                            }).FirstOrDefault();
            return this.View(viewModel);
        }
    }
}
