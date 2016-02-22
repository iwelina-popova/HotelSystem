namespace HotelSystem.Services.Data.Contracts
{
    using System.Linq;

    using HotelSystem.Data.Models;

    public interface IRoomsService
    {
        IQueryable<Room> GetAllRooms();

        IQueryable<Room> GetAllWithDeleted();

        Room GetById(int id);

        void CreateRoom(Room room);

        void Update();

        void Delete(int id);
    }
}
