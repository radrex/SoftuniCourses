namespace PetStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using static DataValidation.DataValidation;

    public class Brand
    {
        //------------ Properties ------------
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        //------------ Toy [FK] ------------
        public ICollection<Toy> Toys { get; set; } = new HashSet<Toy>();

        //------------ Food [FK] -----------
        public ICollection<Food> Foods { get; set; } = new HashSet<Food>();
    }
}
