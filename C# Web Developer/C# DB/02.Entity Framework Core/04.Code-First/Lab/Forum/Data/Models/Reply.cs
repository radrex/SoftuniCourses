namespace Forum.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.Reply;

    public class Reply
    {
        //--------------- Properties ----------------
        public int Id { get; set; }

        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        //--------------- Post ----------------
        public int PostId { get; set; }
        public Post Post { get; set; }

        //--------------- User ----------------
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
