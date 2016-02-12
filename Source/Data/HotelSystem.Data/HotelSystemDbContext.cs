﻿namespace HotelSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using HotelSystem.Data.Common.Models;
    using HotelSystem.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class HotelSystemDbContext : IdentityDbContext<User>
    {
        public HotelSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Hotel> Hotels { get; set; }

        public IDbSet<HotelRooms> HotelRooms { get; set; }

        public IDbSet<Room> Rooms { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public static HotelSystemDbContext Create()
        {
            return new HotelSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
