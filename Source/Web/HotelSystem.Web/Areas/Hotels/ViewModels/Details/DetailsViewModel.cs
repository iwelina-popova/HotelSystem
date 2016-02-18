namespace HotelSystem.Web.Areas.Hotels.ViewModels.Details
{
    using System.Collections.Generic;

    public class DetailsViewModel
    {
        public HotelDetailsViewModel Hotel { get; set; }

        public IEnumerable<HotelRoomViewModel> HotelRooms { get; set; }
    }
}
