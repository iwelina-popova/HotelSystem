namespace HotelSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using HotelSystem.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        [Required]
        [Range(1, 10)]
        public int Rate { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }
    }
}
