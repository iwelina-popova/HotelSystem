namespace HotelSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
    }
}