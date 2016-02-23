namespace HotelSystem.Web.Areas.Hotels.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Areas.Hotels.ViewModels.Details;
    using HotelSystem.Web.Controllers;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class DetailsController : BaseController
    {
        private IHotelsService hotels;
        private IHotelRoomsService hotelRooms;

        public DetailsController(
            IHotelsService hotelsService,
            IHotelRoomsService hotelRoomsService)
        {
            this.hotels = hotelsService;
            this.hotelRooms = hotelRoomsService;
        }

        public ActionResult HotelDetails(int id = 1)
        {
            var hotel = this.Cache.Get(
                    "hotel" + id,
                    () => this.hotels
                                .GetAll()
                                .To<HotelDetailsViewModel>()
                                .Where(h => h.Id == id)
                                .FirstOrDefault(),
                    24 * 60 * 60);

            var hotelRooms = this.Cache.Get(
                "hotelRooms",
                () => this.hotelRooms
                            .GetUniqueRoomTypesInHotel(hotel.Id)
                            .To<HotelRoomViewModel>()
                            .ToList(),
                24 * 60 * 60);

            var viewModel = new DetailsViewModel
            {
                Hotel = hotel,
                HotelRooms = hotelRooms
            };

            return this.View(viewModel);
        }
    }
}
