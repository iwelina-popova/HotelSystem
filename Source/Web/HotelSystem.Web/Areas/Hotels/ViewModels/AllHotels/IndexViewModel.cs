namespace HotelSystem.Web.Areas.Hotels.ViewModels.AllHotels
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<HotelViewModel> Hotels { get; set; }
    }
}
