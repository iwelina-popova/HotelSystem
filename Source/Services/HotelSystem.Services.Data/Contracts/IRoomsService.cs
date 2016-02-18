namespace HotelSystem.Services.Data.Contracts
{
    using System.Linq;

    using HotelSystem.Data.Models;

    public interface IRoomsService
    {
        IQueryable<Room> GetAllRooms();
    }
}
