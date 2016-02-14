namespace HotelSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Web.Infrastructure.Mapping;
    using HotelSystem.Web.ViewModels.Home;
    using System;
    using Data.Models;
    using Services.Data.Contracts;
    using System.Web;
    public class HomeController : BaseController
    {
        private IHomeService contacts;

        public HomeController(IHomeService contactsService)
        {
            this.contacts = contactsService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        // GET: /Home/Contact
        [HttpGet]
        public ActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var contact = this.Mapper.Map<Contact>(model);
                this.contacts.AddContact(contact);

                // TODO: Inform client information was successfully saved.
                return this.View();
            }

            throw new HttpException(400, "Invalid!");
        }
    }
}
