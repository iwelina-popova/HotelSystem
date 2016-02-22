namespace HotelSystem.Web.Areas.Administration.ViewModels.Rooms
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class RoomViewModel : IMapFrom<Room>
    {
        [Required]
        public int Id { get; set; }

        public RoomType Type { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
