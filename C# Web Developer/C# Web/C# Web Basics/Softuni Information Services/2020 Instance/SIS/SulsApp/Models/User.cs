namespace SulsApp.Models
{
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser<string>
    {
        //------------- CONSTRUCTORS --------------
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        //------------ Submission [FK] -----------
        public virtual ICollection<Submission> Submissions { get; set; }    // VIRTUAL for Lazy Loading
    }
}
