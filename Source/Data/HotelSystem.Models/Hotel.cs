﻿namespace HotelSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Hotel
    {
        private ICollection<Rating> ratings;

        public Hotel()
        {
            this.ratings = new HashSet<Rating>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public Location Lcation { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public int ParkingId { get; set; }

        public virtual Parking Parking { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
