namespace HotelSystem.Services.Data
{
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
    }
}
