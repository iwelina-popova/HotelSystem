namespace HotelSystem.Services.Data.Contracts
{
    using System.Linq;

    using HotelSystem.Data.Models;

    public interface IHotelRoomsService
    {
        IQueryable<HotelRoom> GetAllRoomsInHotel(int hotelId);
    }
}
