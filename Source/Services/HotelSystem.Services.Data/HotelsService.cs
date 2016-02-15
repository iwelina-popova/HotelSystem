namespace HotelSystem.Services.Data
{
    using System.Linq;

    using HotelSystem.Data.Common;
    using HotelSystem.Data.Models;
    using HotelSystem.Services.Data.Contracts;
    using HotelSystem.Services.Web;

    public class HotelsService : IHotelsService
    {
        private readonly IDbRepository<Hotel> hotels;
        private readonly IIdentifierProvider identifierProvider;

        public HotelsService(IDbRepository<Hotel> hotelsService, IIdentifierProvider identifierProvider)
        {
            this.hotels = hotelsService;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Hotel> GetAll()
        {
            var all = this.hotels.All();
            return all;
        }

        public Hotel GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            return this.hotels.GetById(intId);
        }
    }
}
