namespace Forum.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.Post;

    public class Post
    {
        //--------------- Properties ----------------
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        //--------------- Author ----------------
        public int AuthorId { get; set; }
        public User Author { get; set; }

        //-------------- Category ---------------
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
        public ICollection<PostTag> Tags { get; set; } = new List<PostTag>();
    }
}
