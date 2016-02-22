namespace HotelSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using HotelSystem.Common;
    using HotelSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AdminController : BaseController
    {
    }
}
