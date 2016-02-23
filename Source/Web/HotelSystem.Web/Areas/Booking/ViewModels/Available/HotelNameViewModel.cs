namespace HotelSystem.Web.Areas.Booking.ViewModels.Available
{
    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class HotelNameViewModel : IMapFrom<Hotel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
