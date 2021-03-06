﻿namespace HotelSystem.Web.Areas.Administration.ViewModels.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        [Required]
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
