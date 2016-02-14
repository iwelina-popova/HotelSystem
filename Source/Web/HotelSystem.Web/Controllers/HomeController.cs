namespace HotelSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using HotelSystem.Web.Infrastructure.Mapping;
    using HotelSystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
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
        public ActionResult Contact()
        {
            return this.View();
        }

        //public ActionResult Contact(ContactViewModel model)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //    }
        //}
    }
}
