namespace HotelSystem.Services.Data
{
    using System;
    using System.Linq;

    using HotelSystem.Data.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;

    public class HotelRoomsService : IHotelRoomsService
    {
        private IDbRepository<HotelRoom> hotelRooms;

        public HotelRoomsService(IDbRepository<HotelRoom> hotelRooms)
        {
            this.hotelRooms = hotelRooms;
        }

        public IQueryable<HotelRoom> GetAllRoomsInHotel(int hotelId)
        {
            return this.hotelRooms
                .All()
                .Where(hr => hr.HotelId == hotelId);
        }

        public IQueryable<HotelRoom> GetUniqueRoomTypesInHotel(int hotelId)
        {
            return this.hotelRooms
                .All()
                .Where(hr => hr.HotelId == hotelId)
                .GroupBy(hr => hr.Room.Type)
                .Select(hr => hr.FirstOrDefault());
        }

        public IQueryable<HotelRoom> GetAllFreeRoomsInHotelForPeriod(int hotelId, int capacity, DateTime from, DateTime to)
        {
            return this.hotelRooms
                .All()
                .Where(hr => hr.HotelId == hotelId &&
                             hr.Room.Capacity >= capacity &&
                            !hr.Booked);
        }

        public IQueryable<HotelRoom> GetAllFreeRoomsInHotel(int hotelId, int roomId)
        {
            return this.hotelRooms
                .All()
                .Where(hr => hr.HotelId == hotelId &&
                             hr.RoomId == roomId &&
                            !hr.Booked);
        }

        public HotelRoom FreeHotelRoom(string hotelName, RoomType type)
        {
            return this.hotelRooms.All()
                .Where(hr => !hr.Booked &&
                       hr.Hotel.Name == hotelName &&
                       hr.Room.Type == type)
                .FirstOrDefault();
        }

        public HotelRoom FreeHotelRoom(int hotelId, int roomId)
        {
            return this.hotelRooms.All()
                .Where(hr => !hr.Booked &&
                       hr.HotelId == hotelId &&
                       hr.RoomId == roomId)
                .FirstOrDefault();
        }

        public void Update()
        {
            this.hotelRooms.SaveChanges();
        }
    }
}
