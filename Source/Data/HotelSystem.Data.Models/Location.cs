namespace HotelSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Common.Models;

    public class Location : BaseModel<int>
    {
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
