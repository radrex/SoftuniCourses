namespace PetStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.DataValidation;
    using static DataValidation.DataValidation.Category;

    public class Category
    {
        //------------ Properties ------------
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        //------------ Pet [FK] -----------
        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        //------------ Toy [FK] -----------
        public ICollection<Toy> Toys { get; set; } = new HashSet<Toy>();

        //------------ Food [FK] -----------
        public ICollection<Food> Foods { get; set; } = new HashSet<Food>();
    }
}
