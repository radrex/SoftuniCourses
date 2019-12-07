namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Projection
    {
        //--------------- Properties ----------------
        [Key]
        public int Id { get; set; }

        //-------- Movie -------- [FK]
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        //-------- Hall -------- [FK]
        [Required]
        public int HallId { get; set; }
        public Hall Hall { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        //--------------- Collections ---------------
        //-------- Ticket -------- [FK]
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
