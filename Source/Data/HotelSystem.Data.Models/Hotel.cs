namespace HotelSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Common.Models;

    public class Hotel : BaseModel<int>
    {
        private ICollection<Rating> ratings;
        private ICollection<HotelRoom> rooms;
        private ICollection<Image> photosSource;

        public Hotel()
        {
            this.ratings = new HashSet<Rating>();
            this.rooms = new HashSet<HotelRoom>();
            this.photosSource = new HashSet<Image>();
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

        public bool RoomService { get; set; }

        public virtual ICollection<Image> PhotosSource
        {
            get { return this.photosSource; }
            set { this.photosSource = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<HotelRoom> Rooms
        {
            get { return this.rooms; }
            set { this.rooms = value; }
        }
    }
}
