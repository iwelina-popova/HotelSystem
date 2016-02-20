namespace HotelSystem.Web.Areas.Hotels.ViewModels.Details
{
    using System.Collections.Generic;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class RoomViewModel : IMapFrom<Room>
    {
        public int Id { get; set; }

        public RoomType Type { get; set; }

        public string Description { get; set; }

        public bool AirConditioning { get; set; }

        public bool FreeWiFi { get; set; }

        public bool HairDryer { get; set; }

        public bool Iron { get; set; }

        public bool TV { get; set; }

        public IEnumerable<string> Images { get; set; }
    }
}
