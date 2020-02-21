namespace IRunes.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Track
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
