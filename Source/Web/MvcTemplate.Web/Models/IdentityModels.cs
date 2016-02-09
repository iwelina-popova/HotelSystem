namespace HotelSystem.Web.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using HotelSystem.Models;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}