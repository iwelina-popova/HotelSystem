namespace HotelSystem.Web.Areas.Profile.ViewModels.Info
{
    using System;

    using AutoMapper;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class BookingViewModel : IMapFrom<HotelSystem.Data.Models.Booking>, IHaveCustomMappings
    {
        public DateTime BookedFrom { get; set; }

        public DateTime BookedTo { get; set; }

        public string HotelName { get; set; }

        public RoomType RoomType { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<HotelSystem.Data.Models.Booking, BookingViewModel>()
                .ForMember(m => m.HotelName, opt => opt.MapFrom(m => m.HotelRooms.Hotel.Name))
                .ForMember(m => m.RoomType, opt => opt.MapFrom(m => m.HotelRooms.Room.Type));
        }
    }
}
