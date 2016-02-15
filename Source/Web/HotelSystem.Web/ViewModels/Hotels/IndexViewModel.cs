namespace HotelSystem.Web.ViewModels.Hotels
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<HotelViewModel> Hotels { get; set; }
    }
}
