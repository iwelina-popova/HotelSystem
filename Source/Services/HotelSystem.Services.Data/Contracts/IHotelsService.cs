namespace HotelSystem.Services.Data.Contracts
{
    using System.Linq;

    using HotelSystem.Data.Models;

    public interface IHotelsService
    {
        IQueryable<Hotel> GetAll();

        Hotel GetById(string id);
    }
}
