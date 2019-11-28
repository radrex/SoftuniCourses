namespace Forum.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.Tag;

    public class Tag
    {
        //--------------- Properties ----------------
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<PostTag> Posts { get; set; } = new List<PostTag>();
    }
}
