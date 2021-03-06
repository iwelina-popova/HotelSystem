﻿namespace HotelSystem.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class ContactInputModel : IMapTo<Contact>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(30, ErrorMessage = "The {0} must be no longer than {1}.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must have any content and be no longer than {2}.", MinimumLength = 5)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }
    }
}
