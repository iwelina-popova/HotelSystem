namespace HotelSystem.Web.Controllers
{
    using System.Web.Mvc;

    using HotelSystem.Services.Web;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }
    }
}
