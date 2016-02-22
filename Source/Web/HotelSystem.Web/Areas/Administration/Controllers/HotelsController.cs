namespace HotelSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Areas.Administration.ViewModels.Hotels;
    using HotelSystem.Web.Controllers;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class HotelsController : AdminController
    {
        private IHotelsService hotels;

        public HotelsController(IHotelsService hotelsService)
        {
            this.hotels = hotelsService;
        }

        // GET: Administration/Hotels
        public ActionResult Index()
        {
            var allHotels = this.hotels
                .GetAllWithDeleted()
                .OrderBy(h => h.Id)
                .To<HotelViewModel>();

            return this.View(allHotels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var hotel = this.Mapper.Map<Hotel>(model);
            var location = new Location()
            {
                Country = model.Country,
                City = model.City,
                Address = model.Address
            };
            hotel.Location = location;
            this.hotels.CreateHotel(hotel);

            this.TempData["Success"] = "Hotel was successful added!";
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            var hotel = this.hotels.GetById(id);
            var hotelModel = this.Mapper.Map<HotelEditModel>(hotel);

            return this.View("Edit", hotelModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelEditModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewBag.Error = ModelValidationErrors.InvalidModel;
                return this.View(model);
            }

            var hotel = this.hotels.GetById(model.Id);
            if (hotel == null)
            {
                this.TempData["Error"] = ModelValidationErrors.EditDeletedEntity;
                return this.RedirectToAction("Index");
            }

            hotel.Name = model.Name;
            hotel.Description = model.Description;
            hotel.Phone = model.Phone;
            hotel.Fax = model.Fax;
            hotel.Email = model.Email;
            hotel.Facebook = model.Facebook;
            hotel.Stars = model.Stars;
            this.hotels.Update();

            this.TempData["Success"] = "Hotel was successful edited!";
            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                this.hotels.Delete(id);
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
