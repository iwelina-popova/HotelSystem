namespace HotelSystem.Services.Data
{
    using System.Linq;

    using HotelSystem.Data.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;

    public class BookingsService : IBookingsService
    {
        private readonly IDbRepository<Booking> bookings;
        private readonly IDbRepository<HotelRoom> hotelRooms;

        public BookingsService(IDbRepository<Booking> bookings, IDbRepository<HotelRoom> hotelRooms)
        {
            this.bookings = bookings;
            this.hotelRooms = hotelRooms;
        }

        public IQueryable<Booking> BookingByEmail(string email)
        {
            return this.bookings
                .All()
                .Where(b => b.Email == email);
        }

        public void CreateBooking(Booking booking)
        {
            this.bookings.Add(booking);
            this.hotelRooms
                .GetById(booking.HotelRoomsId)
                .Booked = true;
            this.bookings.SaveChanges();
        }

        public void Delete(int id)
        {
            var booking = this.bookings.GetById(id);
            this.bookings.Delete(booking);
            this.bookings.SaveChanges();
        }

        public IQueryable<Booking> GetAllWithDeleted()
        {
            return this.bookings.AllWithDeleted();
        }

        public Booking GetById(int id)
        {
            return this.bookings.GetById(id);
        }

        public void Update()
        {
            this.bookings.SaveChanges();
        }
    }
}
