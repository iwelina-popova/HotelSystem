namespace HotelSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        [Required]
        [MaxLength(200)]
        public string Source { get; set; }
    }
}
