namespace PetStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.DataValidation;

    public class Food
    {
        //------------ Properties ------------
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        public double Weight { get; set; } // in KG
        public DateTime ExpirationDate { get; set; }
        public decimal Price { get; set; }

        //------------ Brand [FK] -----------
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        //------------ Category [FK] -----------
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //------------ FoodOrder [FK] MAPPING TABLE -----------
        public ICollection<FoodOrder> Orders { get; set; } = new HashSet<FoodOrder>();
    }
}
