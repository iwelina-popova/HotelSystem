namespace HotelSystem.Services.Data.Contracts
{
    using System.Linq;

    using HotelSystem.Data.Models;

    public interface IHotelsService
    {
        void CreateHotel(Hotel hotel);

        IQueryable<Hotel> GetAll();

        IQueryable<Hotel> GetAllWithDeleted();

        Hotel GetById(int id);

        void Update();

        void Delete(int id);
    }
}
