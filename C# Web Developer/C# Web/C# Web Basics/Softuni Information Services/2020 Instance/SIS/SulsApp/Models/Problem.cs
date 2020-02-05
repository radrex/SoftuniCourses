namespace SulsApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Problem
    {
        //------------- CONSTRUCTORS --------------
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        //-------------- PROPERTIES ---------------
        public string Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public int Points { get; set; }

        //------------ Submission [FK] -----------
        public virtual ICollection<Submission> Submissions { get; set; }    // VIRTUAL for Lazy Loading
    }
}
