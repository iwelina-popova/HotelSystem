namespace HotelSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.Areas.Administration.ViewModels.Users;
    using HotelSystem.Web.Controllers;
    using HotelSystem.Web.Infrastructure.Mapping;

    using Microsoft.AspNet.Identity;

    public class UsersController : BaseController
    {
        private IUsersService users;

        public UsersController(IUsersService usersService)
        {
            this.users = usersService;
        }

        // GET: Administration/Users
        public ActionResult Index()
        {
            var allUsers = this.users
                .GetAllWithDeleted()
                .OrderBy(u => u.Id)
                .To<UserViewModel>();
            return this.View(allUsers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this.Mapper.Map<User>(model);
            this.users.CreateUser(user, model.Password);

            this.TempData["Success"] = "User was successful added!";
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = this.users.GetById(id);
            var userModel = this.Mapper.Map<UserEditModel>(user);

            return this.View("Edit", userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewBag.Error = ModelValidationErrors.InvalidModel;
                return this.View(model);
            }

            var user = this.users.GetById(model.Id);
            this.Mapper.Map<User>(model);
            this.users.Update();

            this.TempData["Success"] = "User was successful edited!";
            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (id == this.User.Identity.GetUserId())
            {
                this.TempData["Error"] = "Cannot delete yourself";
                return this.RedirectToAction("Index");
            }

            try
            {
                this.users.Delete(id);
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
