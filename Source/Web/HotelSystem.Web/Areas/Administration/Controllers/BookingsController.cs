namespace HotelSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Common;
    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Areas.Administration.ViewModels.Bookings;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class BookingsController : AdminController
    {
        private IBookingsService bookings;
        private IHotelRoomsService hotelRooms;

        public BookingsController(IBookingsService bookingsService, IHotelRoomsService hotelRoomsService)
        {
            this.bookings = bookingsService;
            this.hotelRooms = hotelRoomsService;
        }

        public ActionResult Index()
        {
            var allBookings = this.bookings
                .GetAllWithDeleted()
                .OrderBy(h => h.Id)
                .To<BookingViewModel>();

            return this.View(allBookings);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var booking = this.Mapper.Map<HotelSystem.Data.Models.Booking>(model);
            var freeRoom = this.hotelRooms.FreeHotelRoom(model.HotelName, model.RoomType);

            if (freeRoom == null)
            {
                this.TempData["Error"] = "There's no available rooms!";
                return this.View(model);
            }

            booking.HotelRoomsId = freeRoom.Id;
            this.bookings.CreateBooking(booking);

            freeRoom.Booked = true;
            this.hotelRooms.Update();

            this.TempData["Success"] = "Booking was successful!";
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            var booking = this.bookings.GetById(id);
            var bookingModel = this.Mapper.Map<BookingEditModel>(booking);

            return this.View("Edit", bookingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookingEditModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewBag.Error = ModelValidationErrors.InvalidModel;
                return this.View(model);
            }

            var booking = this.bookings.GetById(model.Id);
            if (booking == null)
            {
                this.TempData["Error"] = ModelValidationErrors.EditDeletedEntity;
                return this.RedirectToAction("Index");
            }

            booking.BookedFrom = model.BookedFrom;
            booking.BookedTo = model.BookedTo;
            this.bookings.Update();

            this.TempData["Success"] = "Booking was successful edited!";
            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                this.bookings.Delete(id);
            }
            catch (Exception e)
            {
                this.TempData["Error"] = e.Message;
                return this.RedirectToAction("Index");
            }

            this.TempData["Success"] = "Deleted";
            return this.RedirectToAction("Index");
        }
    }
}
