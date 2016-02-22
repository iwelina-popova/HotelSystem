namespace HotelSystem.Web.Areas.Administration.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class UserEditModel : IMapFrom<User>, IMapTo<User>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}
