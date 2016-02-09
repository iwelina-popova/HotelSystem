namespace HotelSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Parking
    {
        [Key]
        public int Id { get; set; }

        public bool Free { get; set; }
        
        public decimal? Price { get; set; }
    }
}