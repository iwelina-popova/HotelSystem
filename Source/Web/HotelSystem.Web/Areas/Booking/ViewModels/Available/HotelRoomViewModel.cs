namespace HotelSystem.Web.Areas.Booking.ViewModels.Available
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

        public decimal Price { get; set; }

        public int Size { get; set; }

        public int Capacity { get; set; }

        public bool AirConditioning { get; set; }

        public bool Balcom { get; set; }

        public bool Bathroom { get; set; }

        public bool FreeWiFi { get; set; }

        public bool HairDryer { get; set; }

        public bool Heating { get; set; }

        public bool Iron { get; set; }

        public bool Minibar { get; set; }

        public bool Telephone { get; set; }

        public bool TV { get; set; }

        public IEnumerable<BedOptions> Beds { get; set; }

        public IEnumerable<string> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<HotelRoom, HotelRoomViewModel>()
                .ForMember(m => m.RoomType, opt => opt.MapFrom(m => m.Room.Type))
                .ForMember(m => m.RoomId, opt => opt.MapFrom(m => m.Room.Id))
                .ForMember(m => m.Description, opt => opt.MapFrom(m => m.Room.Description))
                .ForMember(m => m.Price, opt => opt.MapFrom(m => m.Room.Price))
                .ForMember(m => m.Size, opt => opt.MapFrom(m => m.Room.Size))
                .ForMember(m => m.Capacity, opt => opt.MapFrom(m => m.Room.Capacity))
                .ForMember(m => m.AirConditioning, opt => opt.MapFrom(m => m.Room.AirConditioning))
                .ForMember(m => m.Balcom, opt => opt.MapFrom(m => m.Room.Balcon))
                .ForMember(m => m.Bathroom, opt => opt.MapFrom(m => m.Room.Bathroom))
                .ForMember(m => m.FreeWiFi, opt => opt.MapFrom(m => m.Room.FreeWiFi))
                .ForMember(m => m.HairDryer, opt => opt.MapFrom(m => m.Room.HairDryer))
                .ForMember(m => m.Heating, opt => opt.MapFrom(m => m.Room.Heating))
                .ForMember(m => m.Iron, opt => opt.MapFrom(m => m.Room.Iron))
                .ForMember(m => m.Telephone, opt => opt.MapFrom(m => m.Room.Telephone))
                .ForMember(m => m.TV, opt => opt.MapFrom(m => m.Room.TV))
                .ForMember(m => m.Beds, opt => opt.MapFrom(m => m.Room.BedOptions))
                .ForMember(m => m.Images, opt => opt.MapFrom(m => m.Room.PhotosSource.Select(i => i.Source)));
        }
    }
}
