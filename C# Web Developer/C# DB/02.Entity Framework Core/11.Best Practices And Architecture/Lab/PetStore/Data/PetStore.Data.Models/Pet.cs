namespace PetStore.Data.Models
{
    using Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.DataValidation.Pet;

    public class Pet
    {
        //------------ Properties ------------
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Price { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        //------------ Breed [FK] -----------
        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        //------------ Category [FK] -----------
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //------------ Order [FK] -----------
        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
