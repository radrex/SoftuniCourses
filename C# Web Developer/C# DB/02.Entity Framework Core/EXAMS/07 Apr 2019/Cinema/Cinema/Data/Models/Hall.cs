namespace Cinema.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Hall
    {
        //--------------- Properties ----------------
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        public bool Is4Dx { get; set; }
        public bool Is3D { get; set; }

        //--------------- Collections --------------- 
        //-------- Projection -------- [FK]
        public ICollection<Projection> Projections { get; set; } = new HashSet<Projection>();

        //-------- Seat -------- [FK]
        public ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
    }
}
