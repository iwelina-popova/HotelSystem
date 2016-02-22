namespace HotelSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Common;
    using HotelSystem.Data.Common.Models;

    public class Location : BaseModel<int>
    {
        [Required]
        [MaxLength(ModelConstraints.LocationMaxLength)]
        public string Country { get; set; }

        [Required]
        [MaxLength(ModelConstraints.LocationMaxLength)]
        public string City { get; set; }

        [Required]
        [MaxLength(ModelConstraints.LocationMaxLength)]
        public string Address { get; set; }
    }
}
