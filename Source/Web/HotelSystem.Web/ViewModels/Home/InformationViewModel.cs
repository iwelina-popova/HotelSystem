namespace HotelSystem.Web.ViewModels.Home
{
    using AutoMapper;

    using HotelSystem.Data.Models;
    using HotelSystem.Web.Infastructures.CustomAttributes;
    using HotelSystem.Web.Infrastructure.Mapping;

    public class InformationViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        [DefaultValue(DefaultText = "500 23th Avenue")]
        public string Address { get; set; }

        [DefaultValue(DefaultText = "New York")]
        public string City { get; set; }

        [DefaultValue(DefaultText = "USA")]
        public string Country { get; set; }

        [DefaultValue(DefaultText = "(00) 222 444 666")]
        public string Phone { get; set; }

        [DefaultValue(DefaultText = " - ")]
        public string Fax { get; set; }

        [DefaultValue(DefaultText = "info@fortunehotel.com")]
        public string Email { get; set; }

        [DefaultValue(DefaultText = "#")]
        public string Facebook { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Hotel, InformationViewModel>()
                .ForMember(m => m.Address, opt => opt.MapFrom(m => m.Location.Address))
                .ForMember(m => m.City, opt => opt.MapFrom(m => m.Location.City))
                .ForMember(m => m.Country, opt => opt.MapFrom(m => m.Location.Country));
        }
    }
}