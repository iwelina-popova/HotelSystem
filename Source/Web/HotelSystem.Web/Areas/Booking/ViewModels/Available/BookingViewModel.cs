namespace HotelSystem.Web.Areas.Booking.ViewModels.Available
{
    using System.Collections.Generic;

    public class BookingViewModel
    {
        public DataSelectorInputModel DataSelector { get; set; }

        public IEnumerable<HotelNameViewModel> HotelsNames { get; set; }
    }
}
