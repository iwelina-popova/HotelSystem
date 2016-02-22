namespace HotelSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Common;
    using HotelSystem.Data.Common.Models;

    public class Room : BaseModel<int>
    {
        private ICollection<BedOptions> bedOptions;
        private ICollection<Image> photosSource;

        public Room()
        {
            this.bedOptions = new HashSet<BedOptions>();
            this.photosSource = new HashSet<Image>();
        }

        [Required]
        public RoomType Type { get; set; }

        public int Size { get; set; }

        [Range(1, 10)]
        public int Capacity { get; set; }

        [Required]
        [MaxLength(ModelConstraints.DescriptionMaxLength)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        //// Room Features

        public bool AirConditioning { get; set; }

        public bool Balcon { get; set; }

        public bool Bathroom { get; set; }

        public bool FreeWiFi { get; set; }

        public bool HairDryer { get; set; }

        public bool Heating { get; set; }

        public bool Iron { get; set; }

        public bool Minibar { get; set; }

        public bool Telephone { get; set; }

        public bool TV { get; set; }

        //// End Room Features

        public virtual ICollection<BedOptions> BedOptions
        {
            get { return this.bedOptions; }
            set { this.bedOptions = value; }
        }

        public virtual ICollection<Image> PhotosSource
        {
            get { return this.photosSource; }
            set { this.photosSource = value; }
        }
    }
}
