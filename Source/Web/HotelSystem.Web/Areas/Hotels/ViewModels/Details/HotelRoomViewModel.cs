namespace HotelSystem.Web.Areas.Hotels.ViewModels.Details
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class HotelRoomViewModel : IMapFrom<HotelRoom>, IHaveCustomMappings
    {
        public int RoomId { get; set; }

        public RoomType RoomType { get; set; }

        public string Description { get; set; }

        public bool AirConditioning { get; set; }

        public bool FreeWiFi { get; set; }

        public bool HairDryer { get; set; }

        public bool Iron { get; set; }

        public bool TV { get; set; }

        public IEnumerable<string> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<HotelRoom, HotelRoomViewModel>()
                .ForMember(m => m.RoomId, opt => opt.MapFrom(m => m.Room.Id))
                .ForMember(m => m.RoomType, opt => opt.MapFrom(m => m.Room.Type))
                .ForMember(m => m.Description, opt => opt.MapFrom(m => m.Room.Description))
                .ForMember(m => m.AirConditioning, opt => opt.MapFrom(m => m.Room.AirConditioning))
                .ForMember(m => m.FreeWiFi, opt => opt.MapFrom(m => m.Room.FreeWiFi))
                .ForMember(m => m.HairDryer, opt => opt.MapFrom(m => m.Room.HairDryer))
                .ForMember(m => m.Iron, opt => opt.MapFrom(m => m.Room.Iron))
                .ForMember(m => m.TV, opt => opt.MapFrom(m => m.Room.TV))
                .ForMember(m => m.Images, opt => opt.MapFrom(m => m.Room.PhotosSource.Select(i => i.Source)));
        }
    }
}
