namespace DemoApp
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        //-------------- PROPERTIES --------------
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Creator { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
