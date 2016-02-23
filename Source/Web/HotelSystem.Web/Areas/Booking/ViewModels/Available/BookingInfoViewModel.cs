namespace HotelSystem.Web.Areas.Booking.ViewModels.Available
{
    using System;
    using System.Collections.Generic;

    public class BookingInfoViewModel
    {
        public IEnumerable<ListRoomsViewModel> Rooms { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public int HotelId { get; set; }
    }
}
