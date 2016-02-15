using AutoMapper;
using HotelSystem.Data.Models;
using HotelSystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSystem.Web.ViewModels.Hotels
{
    public class HotelDetailsViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public double Rating { get; set; }

        public IEnumerable<string> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Hotel, HotelDetailsViewModel>()
                .ForMember(m => m.Country, opt => opt.MapFrom(m => m.Location.Country))
                .ForMember(m => m.City, opt => opt.MapFrom(m => m.Location.City))
                .ForMember(m => m.Address, opt => opt.MapFrom(m => m.Location.Address))
                .ForMember(m => m.Images, opt => opt.MapFrom(m => m.PhotosSource.Select(p => p.Source)))
                .ForMember(m => m.Rating, opt => opt.MapFrom(m => m.Ratings.Select(r => r.Rate).Average()));
        }
    }
}