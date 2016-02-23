namespace HotelSystem.Services.Data.Contracts
{
    using System.Linq;

    using HotelSystem.Data.Models;

    public interface IBookingsService
    {
        IQueryable<Booking> BookingByEmail(string email);

        IQueryable<Booking> GetAllWithDeleted();

        void CreateBooking(Booking booking);

        Booking GetById(int id);

        void Update();

        void Delete(int id);
    }
}
