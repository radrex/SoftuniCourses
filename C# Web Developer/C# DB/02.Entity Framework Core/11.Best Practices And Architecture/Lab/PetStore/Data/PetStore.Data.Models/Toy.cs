namespace PetStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.DataValidation;

    public class Toy
    {
        //------------ Properties ------------
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //------------ Brand [FK] -----------
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        //------------ Category [FK] -----------
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //------------ ToyOrder [FK] MAPPING TABLE -----------
        public ICollection<ToyOrder> Orders { get; set; } = new HashSet<ToyOrder>();
    }
}
