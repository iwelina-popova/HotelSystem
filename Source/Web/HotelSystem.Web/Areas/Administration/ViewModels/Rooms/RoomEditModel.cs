namespace HotelSystem.Web.Areas.Administration.ViewModels.Rooms
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class RoomEditModel : IMapFrom<Room>, IMapTo<Room>
    {
        [Required]
        public int Id { get; set; }

        public RoomType Type { get; set; }

        [Required]
        [StringLength(
            ModelConstraints.DescriptionMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForRange,
            MinimumLength = ModelConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Range(
            ModelConstraints.RoomMinCapacity,
            ModelConstraints.RoomMaxCapacity,
            ErrorMessage = ModelValidationErrors.ValidationErrorForRange)]
        public int Capacity { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<BedOptions> Beds { get; set; }

        [Display(Name = "Air Conditioning")]
        public bool AirConditioning { get; set; }

        public bool Balcon { get; set; }

        public bool Bathroom { get; set; }

        [Display(Name = "Free WiFi")]
        public bool FreeWiFi { get; set; }

        [Display(Name = "Hair Dryer")]
        public bool HairDryer { get; set; }

        public bool Heating { get; set; }

        public bool Iron { get; set; }

        public bool Minibar { get; set; }

        public bool Telephone { get; set; }

        public bool TV { get; set; }
    }
}
