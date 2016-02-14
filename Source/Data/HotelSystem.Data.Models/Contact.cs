namespace HotelSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Common.Models;

    public class Contact : BaseModel<int>
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Subject { get; set; }
    }
}
