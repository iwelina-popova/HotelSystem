namespace HotelSystem.Web.Areas.Administration.ViewModels.Hotels
{
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class HotelEditModel : IMapFrom<Hotel>, IMapTo<Hotel>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(
            ModelConstraints.NameMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForRange,
            MinimumLength = ModelConstraints.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(
            ModelConstraints.DescriptionMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForRange,
            MinimumLength = ModelConstraints.DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(
            ModelConstraints.ContactInfoMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForLength)]
        public string Phone { get; set; }

        [StringLength(
            ModelConstraints.NameMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForLength)]
        public string Fax { get; set; }

        [Required]
        [StringLength(
            ModelConstraints.EmailMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForLength)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(
            ModelConstraints.FacebookMaxLength,
            ErrorMessage = ModelValidationErrors.ValidationErrorForLength)]
        public string Facebook { get; set; }

        [Range(ModelConstraints.HotelMinStars, ModelConstraints.HotelMaxStars)]
        public int Stars { get; set; }
    }
}
