namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Seat
    {
        //--------------- Properties ----------------
        [Key]
        public int Id { get; set; }

        //-------- Customer -------- [FK]
        [Required]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
