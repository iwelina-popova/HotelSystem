namespace HotelSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class HotelRooms
    {
        [Key]
        public int Id { get; set; }

        public int Count { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}