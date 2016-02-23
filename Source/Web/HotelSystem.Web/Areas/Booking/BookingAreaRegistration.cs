namespace HotelSystem.Web.Areas.Booking
{
    using System.Web.Mvc;

    public class BookingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Booking";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Booking_default",
                "Booking/{controller}/{action}/{id}",
                new { action = "Index", constroller = "Available", id = UrlParameter.Optional });
        }
    }
}
