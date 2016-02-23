namespace HotelSystem.Web.Areas.Profile.ViewModels.Info
{
    using System.Collections.Generic;

    public class InfoViewModel
    {
        public UserViewModel User { get; set; }

        public IEnumerable<BookingViewModel> Bookings { get; set; }
    }
}
