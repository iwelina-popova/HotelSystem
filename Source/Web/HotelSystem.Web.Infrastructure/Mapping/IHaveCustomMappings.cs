namespace HotelSystem.Web.Infrastructure.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfiguration configuration);
    }
}
