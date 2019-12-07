namespace Cinema.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Ticket
    {
        //--------------- Properties ----------------
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0.01, Double.MaxValue)]
        public decimal Price { get; set; }

        //-------- Customer -------- [FK]
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //-------- Projection -------- [FK]
        [Required]
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }
    }
}
