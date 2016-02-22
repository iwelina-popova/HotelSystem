namespace HotelSystem.Web.Areas.Administration.ViewModels.Rooms
{
    using System.Collections.Generic;

    using HotelSystem.Data.Models;

    public class RoomWithTypesEditModel
    {
        public RoomEditModel Room { get; set; }

        public IEnumerable<RoomType> Types { get; set; }
    }
}
