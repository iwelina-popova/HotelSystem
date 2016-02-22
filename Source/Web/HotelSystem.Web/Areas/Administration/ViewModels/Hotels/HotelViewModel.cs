namespace HotelSystem.Web.Areas.Administration.ViewModels.Hotels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class HotelViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int RoomsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Hotel, HotelViewModel>()
                .ForMember(m => m.RoomsCount, opt => opt.MapFrom(m => m.Rooms.Count));
        }
    }
}
