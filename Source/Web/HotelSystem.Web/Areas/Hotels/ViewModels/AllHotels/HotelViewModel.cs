namespace HotelSystem.Web.Areas.Hotels.ViewModels.AllHotels
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class HotelViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }

        public IEnumerable<string> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Hotel, HotelViewModel>()
                .ForMember(m => m.Images, opt => opt.MapFrom(m => m.PhotosSource.Select(p => p.Source)))
                .ForMember(m => m.Rating, opt => opt.MapFrom(m => m.Ratings.Any() ? m.Ratings.Select(r => r.Rate).Average() : 0));
        }
    }
}
