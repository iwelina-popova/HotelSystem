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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
