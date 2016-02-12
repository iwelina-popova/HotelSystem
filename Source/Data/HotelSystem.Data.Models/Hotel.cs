namespace HotelSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Common.Models;

    public class Hotel : BaseModel<int>
    {
        private ICollection<Rating> ratings;
        private ICollection<HotelRooms> rooms;

        public Hotel()
        {
            this.ratings = new HashSet<Rating>();
            this.rooms = new HashSet<HotelRooms>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<HotelRooms> Rooms
        {
            get { return this.rooms; }
            set { this.rooms = value; }
        }
    }
}
