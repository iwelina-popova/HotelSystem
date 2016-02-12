namespace HotelSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Common.Models;

    public class Reservation : BaseModel<int>
    {
        public DateTime ReservedOn { get; set; }

        public int HotelRoomsId { get; set; }

        public virtual HotelRooms HotelRooms { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Phone { get; set; }
    }
}
