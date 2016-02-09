namespace HotelSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using HotelSystem.Models;

    public interface IHotelSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Hotel> Hotels { get; set; }

        IDbSet<Room> Rooms { get; set; }

        IDbSet<HotelRooms> HotelRooms { get; set; }

        IDbSet<Location> Location { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<Parking> Parkings { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
