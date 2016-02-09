namespace HotelSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using HotelSystem.Models;

    public class HotelSystemDbContext : IdentityDbContext<User>, IHotelSystemDbContext
    {
        public HotelSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Hotel> Hotels { get; set; }

        public IDbSet<Room> Rooms { get; set; }

        public IDbSet<HotelRooms> HotelRooms { get; set; }

        public IDbSet<Location> Location { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Parking> Parkings { get; set; }

        public static HotelSystemDbContext Create()
        {
            return new HotelSystemDbContext();
        }
    }
}
