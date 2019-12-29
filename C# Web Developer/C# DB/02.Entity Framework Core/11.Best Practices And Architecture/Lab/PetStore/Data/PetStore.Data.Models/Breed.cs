namespace PetStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.DataValidation;

    public class Breed
    {
        //------------ Properties ------------
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        //------------ Pet [FK] -----------
        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
    }
}
