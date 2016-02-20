﻿namespace HotelSystem.Web.Areas.Hotels.Controllers
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
            var allHotels = this.hotels
                .GetAll()
                .To<HotelViewModel>()
                .ToList();

            return this.View(allHotels);
        }
    }
}
