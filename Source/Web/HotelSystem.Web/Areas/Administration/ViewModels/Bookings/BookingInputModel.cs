namespace HotelSystem.Web.Areas.Administration.ViewModels.Bookings
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class BookingInputModel : IMapTo<HotelSystem.Data.Models.Booking>
    {
        [DataType(DataType.Date)]
        [Display(Name = "Booked from")]
        public DateTime BookedFrom { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Booked to")]
        public DateTime BookedTo { get; set; }

        [Required]
        [StringLength(
            ModelConstraints.NameMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForRange,
            MinimumLength = ModelConstraints.NameMinLength)]
        [Display(Name = "Hotel name")]
        public string HotelName { get; set; }

        [Display(Name = "Room Type")]
        public RoomType RoomType { get; set; }

        [Required]
        [StringLength(
            ModelConstraints.NameMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForRange,
            MinimumLength = ModelConstraints.NameMinLength)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(
            ModelConstraints.NameMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForRange,
            MinimumLength = ModelConstraints.NameMinLength)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(ModelConstraints.EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(16, ErrorMessage = "Invalid card number")]
        [Display(Name = "Card number")]
        public string CardNumber { get; set; }
    }
}
