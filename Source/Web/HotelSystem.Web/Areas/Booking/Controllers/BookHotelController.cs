namespace HotelSystem.Web.Areas.Booking.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Controllers;

    public class BookHotelController : BaseController
    {
        private IHotelRoomsService hotelRooms;
        private IBookingsService bookings;

        public BookHotelController(IHotelRoomsService hotelRoomsService, IBookingsService bookingsService)
        {
            this.hotelRooms = hotelRoomsService;
            this.bookings = bookingsService;
        }

        [HttpPost]
        public ActionResult Book(
            int hotelId,
            int roomId,
            string firstName,
            string lastName,
            string email,
            string cardNumber,
            string phone,
            DateTime arrival,
            DateTime departure)
        {
            var hotelRoom = this.hotelRooms
                .FreeHotelRoom(hotelId, roomId);

            var booking = new HotelSystem.Data.Models.Booking()
            {
                HotelRoomsId = hotelRoom.Id,
                BookedFrom = arrival,
                BookedTo = departure,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                CardNumber = cardNumber,
                Phone = phone
            };

            this.bookings.CreateBooking(booking);

            var freeRoomsLeft = this.hotelRooms
                .GetAllFreeRoomsInHotel(hotelId, roomId)
                .Count();

            this.TempData["Success"] = "Your booking finished successfully!";

            return this.Json(new { Count = freeRoomsLeft, Id = roomId });
        }
    }
}
