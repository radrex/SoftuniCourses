namespace Cinema.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Projection")]
    public class ImportProjectionDto
    {
        [Required]
        [XmlElement("MovieId")]
        public int MovieId { get; set; }

        [Required]
        [XmlElement("HallId")]
        public int HallId { get; set; }

        [Required]
        [XmlElement("DateTime")]
        public string DateTime { get; set; }
    }
}
