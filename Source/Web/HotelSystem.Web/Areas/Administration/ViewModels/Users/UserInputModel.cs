namespace HotelSystem.Web.Areas.Administration.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class UserInputModel : IMapTo<User>
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must no longer than {2} characters.", MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must no longer than {2} characters.", MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} is too long.")]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "The {0} must be in range from 1 to 31.")]
        [Display(Name = "Day")]
        public int Day { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "The {0} must be in range from 1 to 12.")]
        [Display(Name = "Month")]
        public int Month { get; set; }

        [Required(ErrorMessage = "The {0} is not valid.")]
        [Display(Name = "Year")]
        public int Year { get; set; }
    }
}
