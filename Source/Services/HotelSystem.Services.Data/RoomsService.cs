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

        public IQueryable<Room> GetAllWithDeleted()
        {
            return this.rooms.AllWithDeleted();
        }

        public Room GetById(int id)
        {
            return this.rooms.GetById(id);
        }

        public void CreateRoom(Room room)
        {
            this.rooms.Add(room);
            this.rooms.SaveChanges();
        }

        public void Update()
        {
            this.rooms.SaveChanges();
        }

        public void Delete(int id)
        {
            var room = this.rooms.GetById(id);
            this.rooms.Delete(room);
            this.rooms.SaveChanges();
        }
    }
}
