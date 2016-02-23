namespace HotelSystem.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Web.ViewModels.Home;

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
            return this.View();
        }

        // GET: /Home/Contact
        [HttpGet]
        public ActionResult Contact()
        {
            return this.View();
        }

        // POST: /Home/Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var contact = this.Mapper.Map<Contact>(model);
                this.contacts.AddContact(contact);

                this.TempData["Success"] = "You contact with us successful!";
                return this.RedirectToAction("Index");
            }

            throw new HttpException(400, "Invalid!");
        }
    }
}
