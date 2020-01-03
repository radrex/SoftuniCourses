namespace PetStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.DataValidation;
    using static DataValidation.DataValidation.User;

    public class User
    {
        //------------ Properties ------------
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        //------------ Order [FK] -----------
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
