namespace HotelSystem.Web.Areas.Hotels.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Areas.Hotels.ViewModels.All;
    using HotelSystem.Web.Controllers;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class AllController : BaseController
    {
        private IHotelsService hotels;

        public AllController(IHotelsService hotelsService)
        {
            this.hotels = hotelsService;
        }

        public ActionResult Index()
        {
            var allHotels = this.Cache.Get(
                "allHotels",
                () => this.hotels
                .GetAll()
                .To<HotelViewModel>()
                .ToList(),
                24 * 60 * 60);

            return this.View(allHotels);
        }
    }
}
