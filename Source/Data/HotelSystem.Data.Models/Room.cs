namespace HotelSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Common.Models;

    public class Room : BaseModel<int>
    {
        private ICollection<BedOptions> bedOptions;
        private ICollection<string> photosSource;

        public Room()
        {
            this.bedOptions = new HashSet<BedOptions>();
            this.photosSource = new HashSet<string>();
        }

        [Required]
        public RoomType Type { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        [Range(1, 10)]
        public int Capacity { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        //// Room Features

        public bool Bathroom { get; set; }

        public bool AirConditiong { get; set; }

        public bool Heating { get; set; }

        public bool TV { get; set; }

        public bool Telephone { get; set; }

        public bool Balcon { get; set; }

        public bool Minibar { get; set; }

        public bool FreeWiFi { get; set; }

        //// End Room Features

        public virtual ICollection<BedOptions> BedOptions
        {
            get { return this.bedOptions; }
            set { this.bedOptions = value; }
        }

        public virtual ICollection<string> PhotosSource
        {
            get { return this.photosSource; }
            set { this.photosSource = value; }
        }
    }
}
