namespace SulsApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Submission
    {
        //------------- CONSTRUCTORS --------------
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        //-------------- PROPERTIES ---------------
        public string Id { get; set; }

        [MaxLength(800)]
        [Required]
        public string Code { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        //------------ Problem [FK] -----------
        public string ProblemId { get; set; }
        public virtual Problem Problem { get; set; } // VIRTUAL for Lazy Loading

        //------------ User [FK] -----------
        public string UserId { get; set; }
        public virtual User User { get; set; }      // VIRTUAL for Lazy Loading
    }
}
