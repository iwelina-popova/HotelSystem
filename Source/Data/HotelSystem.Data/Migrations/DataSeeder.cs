﻿namespace HotelSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using HotelSystem.Common;
    using HotelSystem.Data.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public static class DataSeeder
    {
        internal static void SeedUsers(HotelSystemDbContext context)
        {
            const string userPassword = "asdasd";
            const string adminPassword = "adminadmin";

            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));

            var user = new User()
            {
                Email = "user@user.com",
                FirstName = "First",
                LastName = "Last",
                BirthDate = new DateTime(1950, 2, 20),
                PhoneNumber = "0888888888888"
            };

            userManager.Create(user, userPassword);

            var admin = new User()
            {
                Email = "admin@admin.com",
                FirstName = "Admin",
                LastName = "Admin"
            };

            userManager.Create(admin, adminPassword);

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole() { Name = GlobalConstants.AdministratorRole });
            roleManager.Create(new IdentityRole() { Name = GlobalConstants.StandardUserRole });

            userManager.AddToRoles(admin.Id, GlobalConstants.AdministratorRole, GlobalConstants.StandardUserRole);
            userManager.AddToRole(user.Id, GlobalConstants.StandardUserRole);
        }

        internal static void SeedRooms(HotelSystemDbContext context)
        {
            if (context.Rooms.Any())
            {
                return;
            }

            List<Room> rooms = new List<Room>();
            rooms.Add(new Room()
            {
                Type = RoomType.SingleRoom,
                Capacity = 2,
                Description = "Very nice room",
                Price = 85,
                Size = 50,
                Balcon = true,
                Bathroom = true,
                AirConditiong = true,
                BedOptions = new List<BedOptions>() { BedOptions.Queen },
                FreeWiFi = true,
                Heating = true,
                Minibar = true,
                Telephone = true,
                TV = true
            });

            context.Rooms.AddOrUpdate(rooms.ToArray());
            context.SaveChanges();
        }

        internal static void SeedHotels(HotelSystemDbContext context)
        {
            if (context.Hotels.Any())
            {
                return;
            }

            var rooms = context.Rooms.ToList();
            var users = context.Users.ToList();

            var location = new Location()
            {
                Country = "Bulgaria",
                City = "Varna",
                Address = "Sea Street"
            };

            List<Hotel> hotels = new List<Hotel>();
            var hotel1 = new Hotel()
            {
                Name = "Fortune-Paris",
                Location = location,
                Description = "The most beautiful hotel you ever see.",
                Phone = "025888552",
                Email = "hotel@hotel.com",
                PhotosSource = new List<Image>()
                {
                    new Image()
                    {
                     Source = "../Images/Hotel-Paris/Hotel-Paris.jpg"
                    }
                }
            };
            hotel1.Ratings = new List<Rating>()
            {
                new Rating()
            {
                Rate = 8,
                User = users.First()
            },
                new Rating()
                {
                    Rate = 10,
                    User = users.Last()
                }
            };

            hotels.Add(hotel1);

            context.Hotels.AddOrUpdate(hotels.ToArray());
            context.SaveChanges();
        }
    }
}
