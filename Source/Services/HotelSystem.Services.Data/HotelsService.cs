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

        public HotelsService(IDbRepository<Hotel> hotels, IIdentifierProvider identifierProvider)
        {
            this.hotels = hotels;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Hotel> GetAll()
        {
            return this.hotels.All();
        }

        public Hotel GetById(int id)
        {
            return this.hotels.GetById(id);
        }
    }
}
