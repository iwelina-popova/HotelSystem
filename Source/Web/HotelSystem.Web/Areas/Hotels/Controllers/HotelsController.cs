namespace HotelSystem.Web.Areas.Hotels.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Areas.Hotels.ViewModels.AllHotels;
    using HotelSystem.Web.Areas.Hotels.ViewModels.Details;
    using HotelSystem.Web.Controllers;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class HotelsController : BaseController
    {
        private IHotelsService hotels;
        private IHotelRoomsService hotelRooms;

        public HotelsController(IHotelsService hotelsService, IHotelRoomsService hotelRoomsService)
        {
            this.hotels = hotelsService;
            this.hotelRooms = hotelRoomsService;
        }

        public ActionResult Index()
        {
            var allHotels = this.hotels
                .GetAll()
                .To<HotelViewModel>()
                .ToList();

            var viewModel = new IndexViewModel()
            {
                Hotels = allHotels
            };

            return this.View(viewModel);
        }

        public ActionResult Details(int id = 1)
        {
            var hotel = this.hotels
                .GetAll()
                .To<HotelDetailsViewModel>()
                .Where(h => h.Id == id)
                .FirstOrDefault();

            var hotelRooms = this.hotelRooms
                .GetAllRoomsInHotel(hotel.Id)
                .To<HotelRoomViewModel>()
                .ToList();

            var viewModel = new DetailsViewModel
            {
                Hotel = hotel,
                Rooms = hotelRooms
            };

            return this.View(viewModel);
        }
    }
}
