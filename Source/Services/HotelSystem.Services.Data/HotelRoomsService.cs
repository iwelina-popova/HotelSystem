namespace HotelSystem.Services.Data
{
    using System.Linq;

    using HotelSystem.Data.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;

    public class HotelRoomsService : IHotelRoomsService
    {
        private IDbRepository<HotelRoom> hotelRooms;

        public HotelRoomsService(IDbRepository<HotelRoom> hotelRoomsService)
        {
            this.hotelRooms = hotelRoomsService;
        }

        public IQueryable<HotelRoom> GetAllRoomsInHotel(int hotelId)
        {
            return this.hotelRooms
                .All()
                .Where(hr => hr.HotelId == hotelId);
        }
    }
}
