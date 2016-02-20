namespace HotelSystem.Web.Areas.Hotels
{
    using System.Web.Mvc;

    public class HotelsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Hotels";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Hotels_default",
                url: "Hotels/{controller}/{action}/{id}",
                defaults: new { action = "Index", controller = "All", id = UrlParameter.Optional });
        }
    }
}
