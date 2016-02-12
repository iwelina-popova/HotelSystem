namespace HotelSystem.Data.Models
{
    using HotelSystem.Data.Common.Models;

    public class HotelRooms : BaseModel<int>
    {
        public int Count { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
