namespace HotelSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Areas.Administration.ViewModels.Rooms;
    using HotelSystem.Web.Controllers;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class RoomsController : AdminController
    {
        private IRoomsService rooms;

        public RoomsController(IRoomsService roomsService)
        {
            this.rooms = roomsService;
        }

        // GET: Administration/Hotels
        public ActionResult Index()
        {
            var allRooms = this.rooms
                .GetAllWithDeleted()
                .OrderBy(h => h.Id)
                .To<RoomViewModel>();

            return this.View(allRooms);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var room = this.Mapper.Map<Room>(model);
            this.rooms.CreateRoom(room);

            this.TempData["Success"] = "Room was successful added!";
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            var room = this.rooms.GetById(id);
            var hotelModel = this.Mapper.Map<RoomEditModel>(room);

            return this.View("Edit", hotelModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomEditModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewBag.Error = ModelValidationErrors.InvalidModel;
                return this.View(model);
            }

            var room = this.rooms.GetById(model.Id);
            if (room == null)
            {
                this.TempData["Error"] = ModelValidationErrors.EditDeletedEntity;
                return this.RedirectToAction("Index");
            }

            room.Type = model.Type;
            room.Description = model.Description;
            room.Capacity = model.Capacity;
            room.Price = model.Price;
            room.AirConditioning = model.AirConditioning;
            room.Balcon = model.Balcon;
            room.Bathroom = model.Bathroom;
            room.FreeWiFi = model.FreeWiFi;
            room.HairDryer = model.HairDryer;

            room.Heating = model.Heating;
            room.Iron = model.Iron;
            room.Minibar = model.Minibar;
            room.Telephone = model.Telephone;
            room.TV = model.TV;

            this.rooms.Update();

            this.TempData["Success"] = "Room was successful edited!";
            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                this.rooms.Delete(id);
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
