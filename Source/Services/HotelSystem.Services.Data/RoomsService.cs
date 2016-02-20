namespace HotelSystem.Services.Data
{
    using System.Linq;

    using HotelSystem.Data.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;

    public class RoomsService : IRoomsService
    {
        private IDbRepository<Room> rooms;

        public RoomsService(IDbRepository<Room> rooms)
        {
            this.rooms = rooms;
        }

        public IQueryable<Room> GetAllRooms()
        {
            return this.rooms.All();
        }
    }
}
