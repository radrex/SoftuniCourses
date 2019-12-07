namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        //--------------- Properties ----------------
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [Range(12, 110)]
        public int Age { get; set; }

        [Required]
        [Range(0.01, Double.MaxValue)]
        public decimal Balance { get; set; }

        //--------------- Collections ---------------
        //-------- Ticket -------- [FK]
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
