namespace HotelSystem.Web.Areas.Booking.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Areas.Booking.ViewModels.Available;
    using HotelSystem.Web.Controllers;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class AvailableController : BaseController
    {
        private IHotelsService hotels;
        private IHotelRoomsService hotelRooms;

        public AvailableController(IHotelsService hotelsService, IHotelRoomsService hotelRoomsService)
        {
            this.hotels = hotelsService;
            this.hotelRooms = hotelRoomsService;
        }

        public ActionResult Index()
        {
            var hotelsNames = this.hotels
                .GetAll()
                .To<HotelNameViewModel>()
                .ToList();

            this.ViewBag.HotelsNames = hotelsNames;

            return this.View(new DataSelectorInputModel());
        }

        [HttpPost]
        public ActionResult ViewPrices(DataSelectorInputModel model)
        {
            if (DateTime.Compare(model.Arrival, DateTime.UtcNow) < 0)
            {
                this.TempData["Error"] = "Date cannot be in the past";
                return this.Redirect("Index");
            }

            if (DateTime.Compare(model.Arrival, model.Departure) > 0)
            {
                this.TempData["Error"] = "Arrival date should be earlier than departure";
                return this.RedirectToAction("Index");
            }

            var hotelId = int.Parse(model.HotelName);
            var freeHotelRooms = this.hotelRooms
                .GetAllFreeRoomsInHotelForPeriod(hotelId, model.Capacity, model.Arrival, model.Departure)
                .GroupBy(hr => hr.Room.Type)
                .ToArray();

            IList<ListRoomsViewModel> rooms = new List<ListRoomsViewModel>();
            foreach (var roomType in freeHotelRooms)
            {
                var room = this.Mapper.Map<HotelRoomViewModel>(roomType.First());
                rooms.Add(new ListRoomsViewModel()
                {
                    Room = room,
                    Count = roomType.Count()
                });
            }

            var viewModel = new BookingInfoViewModel()
            {
                Rooms = rooms,
                Arrival = model.Arrival,
                Departure = model.Departure,
                HotelId = hotelId
            };

            return this.View(viewModel);
        }
    }
}
