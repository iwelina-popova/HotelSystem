namespace HotelSystem.Web.Controllers.Hotels
{
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Infrastructure.Mapping;
    using HotelSystem.Web.ViewModels.Hotels;

    public class HotelsController : BaseController
    {
        private IHotelsService hotels;

        public HotelsController(IHotelsService hotelsService)
        {
            this.hotels = hotelsService;
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

        public ActionResult Details(string id)
        {
            var hotel = this.hotels.GetById(id);
            var viewModel = this.Mapper.Map<HotelDetailsViewModel>(hotel);
            return this.View(viewModel);
        }
    }
}
