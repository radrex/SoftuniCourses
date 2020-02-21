namespace SulsApp.ViewModels.Problems
{
    using System.Collections.Generic;

    public class DetailsViewModel
    {
        public string Name { get; set; }
        public IEnumerable<ProblemDetailsSubmissionViewModel> Problems { get; set; }
    }
}
