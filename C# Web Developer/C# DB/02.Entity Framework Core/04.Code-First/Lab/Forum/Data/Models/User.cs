namespace Forum.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.User;

    public class User
    {
        //-------------- Constructors ---------------
        private User() // For EF Core
        {

        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        //--------------- Properties ----------------
        public int Id { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
