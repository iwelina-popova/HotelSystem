namespace HotelSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Common;
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
        [MaxLength(ModelConstraints.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstraints.DescriptionMaxLength)]
        public string Description { get; set; }

        [Range(ModelConstraints.HotelMinStars, ModelConstraints.HotelMaxStars)]
        public int Stars { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        [MaxLength(ModelConstraints.ContactInfoMaxLength)]
        public string Phone { get; set; }

        [MaxLength(ModelConstraints.ContactInfoMaxLength)]
        public string Fax { get; set; }

        [Required]
        [MaxLength(ModelConstraints.EmailMaxLength)]
        public string Email { get; set; }

        [MaxLength(ModelConstraints.FacebookMaxLength)]
        public string Facebook { get; set; }

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
