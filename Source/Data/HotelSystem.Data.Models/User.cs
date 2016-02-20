namespace HotelSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using HotelSystem.Common;
    using HotelSystem.Data.Common;
    using HotelSystem.Data.Common.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Rating> ratings;

        public User()
        {
            this.ratings = new HashSet<Rating>();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [MaxLength(ModelConstraints.NameMaxLength)]
        [MinLength(ModelConstraints.NameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ModelConstraints.NameMaxLength)]
        [MinLength(ModelConstraints.NameMinLength)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
