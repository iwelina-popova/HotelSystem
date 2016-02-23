namespace HotelSystem.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using HotelSystem.Data.Common.Models;

    public class HotelRoom : BaseModel<int>
    {
        private ICollection<Booking> bookings;

        public HotelRoom()
        {
            this.bookings = new HashSet<Booking>();
        }

        [Required]
        [MaxLength(10)]
        public string RoomNumber { get; set; }

        public bool Booked { get; set; }

        public bool StayOver { get; set; }

        public bool CheckOut { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<Booking> Bookings
        {
            get { return this.bookings; }
            set { this.bookings = value; }
        }
    }
}
