namespace SulsApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        //------------- CONSTRUCTORS --------------
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        //-------------- PROPERTIES ---------------
        public string Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //------------ Submission [FK] -----------
        public virtual ICollection<Submission> Submissions { get; set; }    // VIRTUAL for Lazy Loading
    }
}
