﻿namespace HotelSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Common.Models;

    public class Booking : BaseModel<int>
    {
        public DateTime BookedFrom { get; set; }

        public DateTime BookedTo { get; set; }

        public int HotelRoomsId { get; set; }

        public virtual HotelRoom HotelRooms { get; set; }

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

        [Required]
        [MaxLength(16)]
        public string CardNumber { get; set; }
    }
}
