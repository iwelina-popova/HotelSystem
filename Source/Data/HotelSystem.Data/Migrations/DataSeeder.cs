namespace HotelSystem.Data.Migrations
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
        private static Random random = new Random();

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
                Type = RoomType.StandardSingleRoom,
                Capacity = 2,
                Description = @"Overlooking the street or the garden courtyard, the Classic bedroom (15 - 20 sqaure metres) has a 160-centimetre double bed. 
All bedrooms are quiet and bright. They differ in terms of the colours of the fabrics, the cushions, and the armchairs. The décor is refined, elegant, with custom-made 
furniture crafted by recognised French artisans. The atmosphere is warm and comfortable. It radiates the sense of restfulness of a discreetly luxurious cocoon.",
                Price = 70,
                Size = 15,
                AirConditioning = true,
                Bathroom = true,
                BedOptions = new List<BedOptions>() { BedOptions.Queen },
                FreeWiFi = true,
                Heating = true,
                Telephone = true,
                TV = true,
                PhotosSource = new List<Image>()
                {
                    new Image() { Source = "Images/Hotel-Paris/Rooms/StandardSingleRoom.jpg" }
                }
            });
            rooms.Add(new Room()
            {
                Type = RoomType.StandardDoubleRoom,
                Capacity = 2,
                Description = @"Overlooking the street or the garden courtyard, the Classic bedroom (15 - 20 sqaure metres) has a 160-centimetre double bed. 
All bedrooms are quiet and bright. They differ in terms of the colours of the fabrics, the cushions, and the armchairs. The décor is refined, elegant, with custom-made 
furniture crafted by recognised French artisans. The atmosphere is warm and comfortable. It radiates the sense of restfulness of a discreetly luxurious cocoon.",
                Price = 110,
                Size = 20,
                AirConditioning = true,
                Bathroom = true,
                BedOptions = new List<BedOptions>() { BedOptions.Queen, BedOptions.Twin },
                FreeWiFi = true,
                Heating = true,
                Minibar = true,
                Telephone = true,
                TV = true,
                PhotosSource = new List<Image>()
                {
                    new Image() { Source = "Images/Hotel-Paris/Rooms/StandardSingleRoom.jpg" }
                }
            });
            rooms.Add(new Room()
            {
                Type = RoomType.JuniorSuite,
                Capacity = 4,
                Description = @"The junior room (18 to 21 square metres) has a 160-centimetre double bed or two twin beds. These especially quiet rooms have a view over the courtyard 
and garden. Large bathroom with shower or bathtub. The décor is refined, elegant, with custom-made furniture crafted by recognised French artisans. The atmosphere is warm and comfortable. 
It radiates the sense of restfulness of a discreetly luxurious cocoon. Each bedroom differs in terms of the colours of the fabrics, the cushions, and the armchairs.",
                Price = 130,
                Size = 21,
                Balcon = true,
                Bathroom = true,
                AirConditioning = true,
                Heating = true,
                Telephone = true,
                TV = true,
                HairDryer = true,
                Iron = true,
                FreeWiFi = true,
                BedOptions = new List<BedOptions>() { BedOptions.Queen, BedOptions.Sofa },
                PhotosSource = new List<Image>()
                {
                    new Image() { Source = "Images/Hotel-Paris/Rooms/JuniorSuite.jpg" }
                }
            });
            rooms.Add(new Room()
            {
                Type = RoomType.SuperiorSuite,
                Capacity = 4,
                Description = @"The superior suites in the hotel are located on the two highest floors. These are very bright, and have a main room with a sofa-bed, 
                a leather-paneled bureau, and a master bedroom containing a Twin bed or King Size bed. A large dressing room provides an ample amount of storage space. 
                The antique furniture, armchairs, dresser, and bookcase are in balance with the contemporary décor, and are the epitome of the discreetly luxurious French style. 
                There is a surface area of 40 square metres. These rooms will very comfortably accommodate a couple or a family with young children (below the age of 12). 
                Two televisions, one of which is very large screen, are installed for your use.",
                Price = 160,
                Size = 40,
                Balcon = true,
                Bathroom = true,
                AirConditioning = true,
                Heating = true,
                Telephone = true,
                TV = true,
                HairDryer = true,
                Iron = true,
                FreeWiFi = true,
                BedOptions = new List<BedOptions>() { BedOptions.Queen, BedOptions.Twin },
                PhotosSource = new List<Image>()
                {
                    new Image() { Source = "Images/Hotel-Paris/Rooms/SuperiorSuite.jpg" }
                }
            });
            rooms.Add(new Room()
            {
                Type = RoomType.FamilySuite,
                Capacity = 4,
                Description = @"The family Suite consists of two adjoining rooms with a privacy option to protect your peace and quiet as well as your security. 
An area of 40 square metres for accommodating 4 adults or a family with two children. Each room differs in terms of the colors of the fabrics, cushions and armchairs. 
The family suite is equipped with two separate bathrooms one of which has a bathtub. Separate washrooms. Two large closets provide ample storage space.",
                Price = 200,
                Size = 40,
                Balcon = true,
                Bathroom = true,
                AirConditioning = true,
                Heating = true,
                Telephone = true,
                TV = true,
                HairDryer = true,
                Iron = true,
                FreeWiFi = true,
                Minibar = true,
                BedOptions = new List<BedOptions>() { BedOptions.Queen, BedOptions.Queen },
                PhotosSource = new List<Image>()
                {
                    new Image() { Source = "Images/Hotel-Paris/Rooms/FamilySuite.jpg" }
                }
            });
            rooms.Add(new Room()
            {
                Type = RoomType.GrandeSuite,
                Capacity = 6,
                Description = @"Our grande suites located on the 5th and 6th floors are the quintessential feature of our hotel. They have an area of 65 square metres, with a private entrance.
Custom-made furniture and antique objets d'art, absolute quiet and a view over the courtyard of our garden. The carpeting is of pure, thick-pile wool, the drapes and sheers on the windows 
preserve the mood of intimacy and silence. Ipads can be made available to you upon demand. There are 2 very large screen HD televisions in each of the rooms. 
4 adults and 2 children can be accommodated in this apartment.",
                Price = 200,
                Size = 80,
                Balcon = true,
                Bathroom = true,
                AirConditioning = true,
                Heating = true,
                Telephone = true,
                TV = true,
                HairDryer = true,
                Iron = true,
                FreeWiFi = true,
                Minibar = true,
                BedOptions = new List<BedOptions>() { BedOptions.King, BedOptions.Queen, BedOptions.Sofa },
                PhotosSource = new List<Image>()
                {
                    new Image() { Source = "Images/Hotel-Paris/Rooms/GrandeSuite.jpg" }
                }
            });
            rooms.Add(new Room()
            {
                Type = RoomType.VipSuite,
                Capacity = 2,
                Description = @"Your suite experience begins at check-in, where you will enjoy private registration in our Chairman's Lounge. (Please inquire at time of reservation 
for availability.) Our expansive VIP Suites are available as either a One or Two-Bedroom Suite, which can connect to a Tower Deluxe Room for an additional bedroom. 
Savor our stylish, our art décor and tailor your stay to your preferences with mood lighting, individual climate controls, reading lights, and automatic drape and sheer controls.",
                Price = 300,
                Size = 140,
                Balcon = true,
                Bathroom = true,
                AirConditioning = true,
                Heating = true,
                Telephone = true,
                TV = true,
                HairDryer = true,
                Iron = true,
                FreeWiFi = true,
                Minibar = true,
                BedOptions = new List<BedOptions>() { BedOptions.King, BedOptions.Queen, BedOptions.Sofa },
                PhotosSource = new List<Image>()
                {
                    new Image() { Source = "Images/Hotel-Paris/Rooms/VipSuite.jpg" }
                }
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

            List<Hotel> hotels = new List<Hotel>();
            var hotelParis = new Hotel()
            {
                Name = "Fortune-Paris",
                Location = new Location()
                {
                    Country = "France",
                    City = "Paris",
                    Address = "6, rue du Général Lanrezac"
                },
                Description = @"Welcome! Located only 100 metres from the Champs Elysées, on a charming, quiet street between the renowned Avenue CARNOT and Avenue MacMAHON, 
Hotel Fortune-Paris 4 **** offers you the discreet luxury of a true home away from home. Situated in a typical Haussman-style building dating from the 19th century with wrought-iron balconies,
our hotel was completely renovated in 2014 by Interior Design Architect Michel JOUANNET. It has 50 elegant Bedrooms and Suites as well as 2 Prestige Apartments. 
The hotel is the epitome of Parisian elegance. A classical yet contemporary, refined space, with the feeling of a private apartment, where the quality of the décor, the sense of comfort, 
the objets d'art and period pieces are paramount. We have aimed to make this hotel into our Home. Hence, welcome to your home. We are happy to make Fortune-Paris 4 **** your reference 
address in Paris. Francine & Francois DAPREMONT - Owners.",
                Phone = "+33 1 43 80 30 50",
                Email = "fortune-paris@hotel.fr",
                PhotosSource = new List<Image>()
                {
                    new Image()
                    {
                     Source = "Images/Hotel-Paris/Main/Hotel-Paris.jpg"
                    },
                    new Image()
                    {
                     Source = "Images/Hotel-Paris/Hotel-Paris.jpg"
                    },
                    new Image()
                    {
                        Source = "Images/Hotel-Paris/AifelTower.jpg"
                    },
                    new Image()
                    {
                        Source = "Images/Hotel-Paris/c1.jpg"
                    },
                    new Image()
                    {
                        Source = "Images/Hotel-Paris/hotel-president-lobby.jpg"
                    }
                }
            };
            var hotelParkVarna = new Hotel()
            {
                Name = "Pesidence-Varna",
                Location = new Location()
                {
                    Country = "Bulgaria",
                    City = "Varna",
                    Address = "43, Parva Street"
                },
                Description = @"Hotel Residence Varna is the ideal place to stay for business and leisure travelers – just 5 km to the city centre of Varna and 2 km 
to the Black Sea resort St. Constantine&Helena. Its location near the most beautiful beaches of the Black Sea coast makes it a perfect place for dream vacation with sea and sun. 
The Palace of Culture and Sports, The Festival and Congress Center, the theatre and the opera concert hall are all within easy reach. Hotel Residence Varna is 
approx. 25 min from Varna Airport by either taxi or our mini bus transfer.

Hotel Residence Varna is surrounded by a garden with green trees and flowers. The grounds include a seasonally opened outdoor swimming pool with terrace with sun chairs 
and mattresses and a playground for our youngest guests – the children. All Hotel Residence Varna rooms are equipped with individual remote-control air conditioning, 
mini bar, tea and coffee making facilities, safe, Wi-Fi internet, flat screen TV, bathroom with bath tub, bathrobes and slippers. The wellness area includes a modern fitness centre, 
jaccuzzi and sauna.

The elegant and stylish decorated restaurant offers you a continental and healthy breakfast. Here, in a friendly and relaxing atmosphere guests can enjoy at lunch and dinner 
time our a-la carte menu from European gourmet cuisine. The lobby bar offers an extensive choice of drinks and creates the ideal space for socialization between the guests.

Hotel Residence Varna is the magnificent place for your business meetings, team buildings, cultural events and private parties. For meetings and seminars we offer a fully 
equipped conference room for up to 20 persons.",
                Phone = "+359 52 388 222",
                Email = "office@residencevarna.bg",
                PhotosSource = new List<Image>()
                {
                    new Image()
                    {
                     Source = "Images/Hote-Residence-Varna/Main/Residence-Varna.jpg"
                    },
                    new Image()
                    {
                     Source = "Images/Hote-Residence-Varna/Residence-Varna.jpg"
                    },
                    new Image()
                    {
                        Source = "Images/Hote-Residence-Varna/1.jpg"
                    },
                    new Image()
                    {
                        Source = "Images/Hote-Residence-Varna/buffet.jpg"
                    },
                    new Image()
                    {
                        Source = "Images/Hote-Residence-Varna/lobby.jpg"
                    }
                }
            };
            var hotelNewYork = new Hotel()
            {
                Name = "NewYork-Tower",
                Location = new Location()
                {
                    Country = "The USA",
                    City = "New York",
                    Address = "700 8th Avenue"
                },
                Description = @"The NewYork-Tower hotel has pioneered a new era of individuality among Times Square hotels by meeting NYC’s signature urban grit with grandeur. 
NewYork-Tower transforms your stay into a completely contemporary experience – with a front row view to Times Square that’s truly incomparable.  Outside the hotel, guests have access 
to anything and everything Times Square has to offer – 24/7.  Inside, the NewYork-Tower is a medley of inspired New York City amenities.

NewYork-Tower set out to revolutionize the traditional hotel stay by cultivating a dynamic dining experience.  The NewYork-Tower hotel is home to Times Square’s first indoor food market, 
City Kitchen, where guests can delight in the city’s best dishes – without having to travel to taste them.  City Kitchen features seven of New York’s most buzzed about restauranteurs, 
each bringing their most crave-worthy dish to the table. 

In a city that prides itself on never sleeping, the NewYork-Tower keeps guests connected with a state of the art iMac internet lounge and access to hi-speed wifi.
Explore the very best of New York City – inside and outside the Row NYC hotel!",
                Phone = "212-642-4631",
                Email = "hotel@nytower.bg",
                PhotosSource = new List<Image>()
                {
                    new Image()
                    {
                     Source = "Images/Hotel-NewYork-Tower/Main/NewYork-Tower.jpg"
                    },
                    new Image()
                    {
                     Source = "Images/Hotel-NewYork-Tower/NewYork-Tower.jpg"
                    },
                    new Image()
                    {
                     Source = "Images/Hotel-NewYork-Tower/Main/1.jpg"
                    },
                    new Image()
                    {
                     Source = "Images/Hotel-NewYork-Tower/Main/ny.jpg"
                    },
                    new Image()
                    {
                     Source = "Images/Hotel-NewYork-Tower/Main/c4.jpg"
                    },
                    new Image()
                    {
                     Source = "Images/Hotel-NewYork-Tower/Main/chambers.jpg"
                    },
                }
            };

            var users = context.Users.ToList();
            var usersLength = users.Count;
            foreach (var hotel in hotels)
            {
                hotel.Ratings.Add(new Rating()
                {
                    User = users[random.Next(0, usersLength)],
                    Rate = random.Next(1, 10 + 1)
                });
            }

            hotels.Add(hotelParis);
            hotels.Add(hotelParkVarna);
            hotels.Add(hotelNewYork);

            context.Hotels.AddOrUpdate(hotels.ToArray());
            context.SaveChanges();
        }

        internal static void SeedHotelRooms(HotelSystemDbContext context)
        {
            if (context.HotelRooms.Any())
            {
                return;
            }

            var hotel = context.Hotels.FirstOrDefault();

            var count = 0;
            while (count < 7)
            {
                var rooms = context.Rooms.Where(r => r.Type == (RoomType)count).ToList();

                var j = 1;
                for (int i = 1; i <= 10; i++)
                {
                    hotel.Rooms.Add(new HotelRoom()
                    {
                        Room = rooms[0],
                        RoomNumber = j + "0" + i
                    });

                    if (i % 5 == 0)
                    {
                        j++;
                    }
                }

                count++;
            }

            context.Hotels.AddOrUpdate(hotel);
            context.SaveChanges();
        }
    }
}
